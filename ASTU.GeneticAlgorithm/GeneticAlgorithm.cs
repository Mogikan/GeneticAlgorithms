using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    internal abstract class GeneticAlgorithm
    {
        public GeneticAlgorithm()
        {
            _population = new List<Organizm>();            
        }
        private GeneticAlgoritmParameters _geneticAlgorithmParameters;
        private List<Organizm> _population;
        private List<PopulationHistoryItem> _history = new List<PopulationHistoryItem>();
        public IList<PopulationHistoryItem> History
        {
            get
            {
                return _history;
            }
        }
        public abstract Organizm CreateOrganizm();
        public void InitPopulation()
        {
            for (int i = 0; i < _geneticAlgorithmParameters.InitialPopulationSize; i++)
            {
                _population.Add(CreateOrganizm());
            }
        }

        public void Execute(GeneticAlgoritmParameters geneticParameters)
        {
            _geneticAlgorithmParameters = geneticParameters;
            InitPopulation();
            for (int i = 0; i < _geneticAlgorithmParameters.GenerationCount; i++)
            {
                _history.Add(new PopulationHistoryItem()
                {
                    BestOrganismFitness = _population.Max((organism) => MeasureFitness(organism)),
                    WorstOrganismFitness = _population.Min((organism) => MeasureFitness(organism)),
                    AverageOrganismFitness = _population.Average((organism) => MeasureFitness(organism)),
                    Generation = i,
                });
                ExecuteStep();
            }
        }
        public void ExecuteStep()
        {
            ProduceChildren();
            Mutate();
            NaturalSelect();
        }

        internal void NaturalSelect()
        {
            HashSet<int> fightOrganisms = new HashSet<int>();
            HashSet<int> diedOrganisms = new HashSet<int>();
            for (int i = 0; i < _geneticAlgorithmParameters.ReproductionNumber*2; i++)
            {
                int randomFighterIndex1 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize + _geneticAlgorithmParameters.ReproductionNumber*2);
                while (fightOrganisms.Contains(randomFighterIndex1))
                {
                    randomFighterIndex1 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize + _geneticAlgorithmParameters.ReproductionNumber * 2);
                }
                int randomFighterIndex2 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize + _geneticAlgorithmParameters.ReproductionNumber * 2);
                while (randomFighterIndex2 != randomFighterIndex1 && fightOrganisms.Contains(randomFighterIndex2))
                {
                    randomFighterIndex2 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize + _geneticAlgorithmParameters.ReproductionNumber * 2);
                }
                fightOrganisms.Add(randomFighterIndex1);
                fightOrganisms.Add(randomFighterIndex2);
                int deathIndex;
                if (RandomHelper.NextDouble() < _geneticAlgorithmParameters.BadOrganizmDeathProbability)
                {
                    
                    deathIndex = ( MeasureFitness(_population[randomFighterIndex1]) < MeasureFitness(_population[randomFighterIndex2])) ? randomFighterIndex1 : randomFighterIndex2;
                }
                else
                {
                    deathIndex = (MeasureFitness(_population[randomFighterIndex1]) < MeasureFitness(_population[randomFighterIndex2])) ? randomFighterIndex2 : randomFighterIndex1;
                }
                diedOrganisms.Add(deathIndex);
            }
            var newPopulation = new List<Organizm>();
            for (int i = 0; i < _population.Count; i++)
            {
                if (!diedOrganisms.Contains(i))
                {
                    newPopulation.Add(_population[i]);
                }
            }
            _population = newPopulation;
        }

        public abstract double MeasureFitness(Organizm organizm);
        internal void Mutate()
        {
            for (int i = 0; i < _population.Count; i++)
            {
                if (RandomHelper.NextDouble() < _geneticAlgorithmParameters.MutationProbability)
                {
                    var originalOrganizm = _population[i];
                    var mutant = ProduceMutant(_population[i]);
                    Organizm leftOrganizm;
                    if (RandomHelper.NextDouble() < _geneticAlgorithmParameters.GoodOrganizmSurvivalProbability)
                    {
                        leftOrganizm = MeasureFitness(mutant) > MeasureFitness(originalOrganizm) ? mutant : originalOrganizm;
                    }
                    else
                    {
                        leftOrganizm = MeasureFitness(mutant) < MeasureFitness(originalOrganizm) ? mutant : originalOrganizm;
                    }
                    _population[i] = leftOrganizm;
                }
            }
        }
        internal abstract Tuple<Organizm, Organizm> ProduceChildren(Organizm parent1, Organizm parent2);
        internal abstract Organizm ProduceMutant(Organizm organizm);
        HashSet<int> _organizmUsedForReproduction;
        internal void ProduceChildren()
        {
            _organizmUsedForReproduction = new HashSet<int>();
            for (int i = 0; i < _geneticAlgorithmParameters.ReproductionNumber; i++)
            {
                int randomParentIndex1 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize);
                while (_organizmUsedForReproduction.Contains(randomParentIndex1))
                {
                    randomParentIndex1 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize);
                }                
                int randomParentIndex2 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize);
                while (randomParentIndex2!=randomParentIndex1 &&_organizmUsedForReproduction.Contains(randomParentIndex2))
                {
                    randomParentIndex2 = RandomHelper.NextInt(_geneticAlgorithmParameters.InitialPopulationSize);
                }
                _organizmUsedForReproduction.Add(randomParentIndex1);
                _organizmUsedForReproduction.Add(randomParentIndex2);
                var parent1 = _population[randomParentIndex1];
                var parent2 = _population[randomParentIndex2];
                var children = ProduceChildren(parent1, parent2);
                _population.Add(children.Item1);
                _population.Add(children.Item2);                           
            }
        }
    }
}
