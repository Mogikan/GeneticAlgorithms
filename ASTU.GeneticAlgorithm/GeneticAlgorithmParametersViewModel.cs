using ASTU.Model;
using Sparrow.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ASTU.GeneticAlgorithm
{
    public class GeneticAlgorithmParametersViewModel : Observable
    {
        public GeneticAlgorithmParametersViewModel()
        {            
            _geneticAlgorithm = new CubeGraphGeneticAlgorithm(Graph.FromFile(@"..\..\GraphData.txt"));
            _startGeneticAlgorithmCommand = new Command<object>((mockParams) => 
            {
                _geneticAlgorithm.Execute(_geneticParameters);
                var averageFitness = new PointsCollection();
                var maxFitness = new PointsCollection();
                var minFitness = new PointsCollection();
                var maxPoints = _geneticAlgorithm.History.Select((historyItem) => new DoublePoint() { Data = historyItem.Generation, Value = historyItem.BestOrganismFitness });
                foreach (var point in maxPoints)
                {
                    maxFitness.Add(point);
                }
                var minPoints = _geneticAlgorithm.History.Select((historyItem) => new DoublePoint() { Data = historyItem.Generation, Value = historyItem.WorstOrganismFitness });
                foreach (var point in minPoints)
                {
                    minFitness.Add(point);
                }
                var averagePoints = _geneticAlgorithm.History.Select((historyItem) => new DoublePoint() { Data = historyItem.Generation, Value = historyItem.AverageOrganismFitness });
                foreach (var point in averagePoints)
                {
                    averageFitness.Add(point);
                }
                AverageFitness = averageFitness;
                MinFitness = minFitness;
                MaxFitness = maxFitness;


            });
        }

        private GeneticAlgorithm _geneticAlgorithm;
        private GeneticAlgoritmParameters _geneticParameters = new GeneticAlgoritmParameters();        
        public int InitialPopulationSize
        {
            get
            {
                return _geneticParameters.InitialPopulationSize;
            }
            set
            {
                _geneticParameters.InitialPopulationSize = value;
                NotifyPropertyChanged(()=>InitialPopulationSize);
            }
        }

     
        public int MaxGridValue
        {
            get
            {
                return GenerationCount;
            }            
        }
        public int GenerationCount
        {
            get
            {
                return _geneticParameters.GenerationCount;
            }
            set
            {
                _geneticParameters.GenerationCount = value;
                NotifyPropertyChanged(() => GenerationCount);
                NotifyPropertyChanged(() => MaxGridValue);
            }
        }
        private ICommand _startGeneticAlgorithmCommand;
        public ICommand StartGeneticAlgorithmCommand
        {
            get
            {
                return _startGeneticAlgorithmCommand;
            }
            set
            {
                _startGeneticAlgorithmCommand = value;
                NotifyPropertyChanged(() => StartGeneticAlgorithmCommand);
            }
        }

        public int ReproductionNumber
        {
            get
            {
                return _geneticParameters.ReproductionNumber;
            }
            set
            {
                _geneticParameters.ReproductionNumber = value;
                NotifyPropertyChanged(() => ReproductionNumber);
            }
        }
        public double MutationProbability
        {
            get
            {
                return _geneticParameters.MutationProbability;
            }
            set
            {
                _geneticParameters.MutationProbability = value;
                NotifyPropertyChanged(() => MutationProbability);
            }
        }
        public double GoodOrganizmSurvivalProbability
        {
            get
            {
                return _geneticParameters.GoodOrganizmSurvivalProbability;
            }
            set
            {
                _geneticParameters.GoodOrganizmSurvivalProbability = value;
                NotifyPropertyChanged(() => GoodOrganizmSurvivalProbability);
            }
        }
        public double BadOrganizmDeathProbability
        {
            get
            {
                return _geneticParameters.BadOrganizmDeathProbability;
            }
            set
            {
                _geneticParameters.BadOrganizmDeathProbability = value;
                NotifyPropertyChanged(() => BadOrganizmDeathProbability);
            }
        }

        private int _gridStep;

        public int GridStep
        {
            get
            {
                return _gridStep;
            }
            set
            {
                _gridStep = value;
                NotifyPropertyChanged(() => GridStep);
            }
        }
        private PointsCollection _averageFitness = new PointsCollection();
        public PointsCollection AverageFitness
        {
            get
            {
                return _averageFitness;
            }
            set
            {
                _averageFitness = value;
                NotifyPropertyChanged(() => AverageFitness);
            }
        }

        private PointsCollection _minFitness = new PointsCollection();
        public PointsCollection MinFitness
        {
            get
            {
                return _minFitness;
            }
            set
            {
                _minFitness = value;
                NotifyPropertyChanged(() => MinFitness);
            }
        }

        private PointsCollection _maxFitness = new PointsCollection();
        public PointsCollection MaxFitness
        {
            get
            {
                return _maxFitness;
            }
            set
            {
                _maxFitness = value;
                NotifyPropertyChanged(() => MaxFitness);
            }
        }

    }
}
