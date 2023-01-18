using System;
using System.Collections.Generic;
using System.Linq;

namespace sortirane_na_chisla_SPISACI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            nums.Sort();
            Console.WriteLine(string.Join(" <= ", nums));
        }
    }
}
