using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GraphVisualizer
{
    public class Graph
    {
        public Graph(int vertexCount, GraphOrientationType orientation = GraphOrientationType.NotOriented)
        {
            _adjacencyMatrix = new int[vertexCount][];
            for (int i = 0; i < vertexCount; i++)
            {
                _adjacencyMatrix[i] = new int[vertexCount];
            }
            _graphOrientationType = orientation;
        }
        
        public Graph(int[][] adjacencyMatrix,GraphOrientationType orientation = GraphOrientationType.NotOriented):this(adjacencyMatrix.Length, orientation)
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
        private int[][] _adjacencyMatrix;
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
        public void DrawGraph()
        {

        }
    }

}
