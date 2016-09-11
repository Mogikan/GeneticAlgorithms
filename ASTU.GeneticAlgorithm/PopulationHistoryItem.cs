namespace ASTU.GeneticAlgorithm
{
    internal class PopulationHistoryItem
    {
        public double BestOrganismFitness { get; set; }
        public double AverageOrganismFitness { get; set; }
        public double WorstOrganismFitness { get; set; }

        public int Generation { get; set;}
    }
}