using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine($"Sum={Sum(list)}");
            double average = Math.Round(Average(list), 2);
            Console.WriteLine($"Average={average}");
        }

        private static double Average(List<int> list)
        {
            double average = 0;
            for (int i = 0; i < list.Count; i++)
            {
                average += list[i];
            }

            average = average / list.Count;

            return average;
        }

        private static int Sum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            
            return sum;
        }
    }
}
