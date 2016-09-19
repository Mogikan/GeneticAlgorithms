using ASTU.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public class Organizm
    {
        public Organizm(Graph graph)
        {
            _organizmBits = new bool[graph.GetNumberOfEdges()];
            for (int i = 0; i < GenesCount; i++)
            {
                _organizmBits[i] = RandomHelper.NextBool();                
            }
            _graph = graph;
        }

        public Organizm(Graph graph,bool[] organizmBits)
        {
            _organizmBits = organizmBits;
            _graph = graph;
        }
        public Organizm(Graph graph, bool[] firstParentGenes, bool[] secondParentGenes):this(graph)
        {
            _organizmBits = ConcatGenes(firstParentGenes, secondParentGenes);
        }

        public double MeasureFitness(Graph graph)
        {
            double penaltyFactor = _graph.VertexCount;
            double vertexScoreFactor = 1;
            var penalty = _organizmBits.Any(bit => bit)?0:1;
            var organizmGraph = _graph.GetSubGraph(_organizmBits);
            var organizmScore = penalty * penaltyFactor;
            for (int i = 0; i < organizmGraph.VertexCount; i++)
            {
                var vertexDegree = organizmGraph.CalculateVertexDegree(i);
                if (vertexDegree == 0 || vertexDegree == 3)
                {
                    organizmScore += 1 * vertexScoreFactor;
                }
                else
                {
                    if (vertexDegree > 3)
                    {
                        organizmScore -= vertexDegree * vertexScoreFactor;
                    }
                }
            }
            return organizmScore;
        }

        public Organizm Mutate(Graph graph)
        {
            var mutantBits = new bool[_organizmBits.Length];
            for (int i = 0; i < GenesCount; i++)
            {
                mutantBits[i] = !_organizmBits[i];
            }
            return new Organizm(graph,mutantBits);
        }

        private bool[] ConcatGenes(bool[] first, bool[] after)
        {
            var bools = new bool[first.Length + after.Length];
            first.CopyTo(bools, 0);
            after.CopyTo(bools, first.Length);
            return bools;
        }

        private Tuple<bool[], bool[]> SliceOrganizm(int cutPoint)
        {
            var parent = _organizmBits;
            bool[] firstOrganizm = parent.Take(cutPoint).ToArray();
            bool[] secondOrganizm = parent.Skip(cutPoint).Take(parent.Length - cutPoint).ToArray();
            return new Tuple<bool[], bool[]>(firstOrganizm, secondOrganizm);
        }        


        private bool[] _organizmBits;
        private Graph _graph;
        
        private int GenesCount
        {
            get
            {
                return _organizmBits.Length;
            }
        }
        public static Tuple<Organizm, Organizm> ProduceChildren(Graph graph,Organizm firstParent, Organizm secondParent)
        {
            int cutLine = RandomHelper.NextInt(firstParent.GenesCount);
            var cuttedGenesParent1 = firstParent.SliceOrganizm(cutLine);
            var cuttedGenesParent2 = secondParent.SliceOrganizm(cutLine);
            Organizm child1 = new Organizm(graph, cuttedGenesParent1.Item1, cuttedGenesParent2.Item2);
            Organizm child2 = new Organizm(graph, cuttedGenesParent2.Item1, cuttedGenesParent1.Item2);
            return new Tuple<Organizm, Organizm>(child1,child2);
        }
    }
}
