using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.Model
{
    public class Graph
    {
        public Graph(int vertexCount, GraphOrientationType orientation = GraphOrientationType.NotOriented)
        {
            _adjacencyMatrix = new double[vertexCount][];
            for (int i = 0; i < vertexCount; i++)
            {
                _adjacencyMatrix[i] = new double[vertexCount];
            }
            _graphOrientationType = orientation;
        }
        
        public Graph(double[][] adjacencyMatrix,GraphOrientationType orientation = GraphOrientationType.NotOriented):this(adjacencyMatrix.Length, orientation)
        {
            for (int i= 0;i< VertexCount;i++)
            {
                for (int j=0;j<VertexCount;j++)
                {
                    _adjacencyMatrix[i][j] = adjacencyMatrix[i][j];
                }
            }        

        }
        private GraphOrientationType _graphOrientationType;
        private double[][] _adjacencyMatrix;
        public void AddEdge(int vertexFrom, int vertexTo, int weight)
        {
            _adjacencyMatrix[vertexFrom][vertexTo] = weight;
            if (_graphOrientationType == GraphOrientationType.NotOriented)
            {
                _adjacencyMatrix[vertexTo][vertexFrom] = weight;
            }
        }

        public int VertexCount
        {
            get
            {
                return _adjacencyMatrix.Length;
            }
        }
        public int CalculateVertexDegree(int vertexNumber)
        {
            int result = _adjacencyMatrix[vertexNumber].Count((weight) => weight > 0);
            for (int i = 0; i < VertexCount; i++)
            {
                result += _adjacencyMatrix[i][i] > 0 ? 1 : 0;
            }
            return result;
        }

        public Graph GetSubGraph(bool[] edgesToInclude)
        {
            int edgeCounter = 0;
            double[][] subGraphAdjancencyMatrix = new double[VertexCount][];
            for (int i = 0; i < VertexCount; i++)
            {
                subGraphAdjancencyMatrix[i] = new double[VertexCount];

                for (int j = 0; j <= i; j++)
                {
                    if (_adjacencyMatrix[i][j] > 0)
                    {
                        if (edgesToInclude[edgeCounter])
                        {
                            subGraphAdjancencyMatrix[i][j] = _adjacencyMatrix[i][j];
                            edgeCounter++;
                        }                        
                    }
                }
            }
            return new Graph(subGraphAdjancencyMatrix);
        }

        public int GetNumberOfEdges()
        {
            int result = 0;
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (_adjacencyMatrix[i][j] > 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        public static Graph FromFile(string filePath)
        {
            using (StreamReader graphReader = new StreamReader(new FileStream(filePath, FileMode.Open)))
            {
                var graphLine = graphReader.ReadLine().TrimEnd();
                var graphLineValues = graphLine.Split(' ');
                var vertexCount = graphLineValues.Length;
                var graphMatrix = new double[vertexCount][];
                for (int i = 0; i < vertexCount; i++)
                {
                    graphMatrix[i] = new double[vertexCount];
                    for (int j = 0; j < vertexCount; j++)
                    {
                        graphMatrix[i][j] = Convert.ToDouble(graphLineValues[j]);
                    }
                    graphLine = graphReader.ReadLine();
                }
                return new Graph(graphMatrix);
            }            
        }
    }

}
