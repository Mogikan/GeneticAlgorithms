using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public class GeneticAlgoritmParameters
    {
        public int InitialPopulationSize { get; set; } = 10;
        public int GenerationCount { get; set; } = 100;
        public int ReproductionNumber { get; set; } = 3;
        public double MutationProbability { get; set; } = 0.05;
        public double GoodOrganizmSurvivalProbability { get; set; } = 0.99;
        public double BadOrganizmDeathProbability { get; set; } = 0.95;

        public GeneticAlgoritmParameters Clone()
        {
            return new GeneticAlgoritmParameters()
            {
                InitialPopulationSize = this.InitialPopulationSize,
                GenerationCount = this.GenerationCount,
                ReproductionNumber = this.ReproductionNumber,
                MutationProbability = this.MutationProbability,
                GoodOrganizmSurvivalProbability = this.GoodOrganizmSurvivalProbability,
                BadOrganizmDeathProbability = this.BadOrganizmDeathProbability,
            };            
        }
    }
}
