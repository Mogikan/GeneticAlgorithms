using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public static class RandomHelper
    {
        private static Random randomGenerator = new Random();
        public static int NextInt(int max)
        {
            return randomGenerator.Next(max);
        }

        public static bool NextBool()
        {
            return Convert.ToBoolean(randomGenerator.Next(2));
        }

        public static double NextDouble()
        {
            return randomGenerator.NextDouble();
        }

    }
}
