using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public class GeneticAlgoritmParameters
    {
        public int InitialPopulationSize { get; set; } = 100;
        public int GenerationCount { get; set; } = 500;
        public int ReproductionNumber { get; set; } = 50;
        public double MutationProbability { get; set; } = 0.02;
        public double GoodOrganizmSurvivalProbability { get; set; } = 0.99;
        public double BadOrganizmDeathProbability { get; set; } = 0.95;
    }
}
