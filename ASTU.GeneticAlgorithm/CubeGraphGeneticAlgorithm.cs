using ASTU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    internal class CubeGraphGeneticAlgorithm : GeneticAlgorithm
    {
        public CubeGraphGeneticAlgorithm(Graph graph)
        {
            _graph = graph;
        }

        private Graph _graph;

        public override Organizm CreateOrganizm()
        {
            return new Organizm(_graph);
        }

        internal override Tuple<Organizm, Organizm> ProduceChildren(Organizm parent1, Organizm parent2)
        {
            return Organizm.ProduceChildren(_graph, parent1, parent2);
        }

        public override double MeasureFitness(Organizm organizm)
        {
            return organizm.MeasureFitness(_graph);
        }

        internal override Organizm ProduceMutant(Organizm organizm)
        {
            return organizm.Mutate(_graph);
        }

    }
}
