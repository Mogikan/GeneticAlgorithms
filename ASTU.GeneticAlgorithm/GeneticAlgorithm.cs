using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public abstract class GeneticAlgorithm
    {
        public GeneticAlgorithm(GeneticAlgoritmParameters geneticParameters)
        {
            _geneticAlgorithmParameters = geneticParameters;
        }
        private GeneticAlgoritmParameters _geneticAlgorithmParameters;

        public void Execute()
        {
            for (int i = 0; i < _geneticAlgorithmParameters.GenerationCount; i++)
            {
                ExecuteStep();
            }
        }
        public void ExecuteStep()
        {
            ProduceChildren();
            Mutate();
            NaturalSelect();
        }

        internal abstract void NaturalSelect();
        internal abstract void Mutate();
        internal abstract void ProduceChildren();
    }
}
