using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public class GeneticAlgoritmParameters
    {
        public int InitialPopulationSize { get; set; }
        public int GenerationCount { get; set; }
        public int ReproductionNumber { get; set; }
        public int MutationProbability { get; set; }
        public int GoodOrganizmSurvivalProbability { get; set; }
        public int BadOrganizmDeathProbability { get; set; }
    }
}
