using System;
using System.Collections.Generic;
using System.Linq;

namespace broi_na_realni_chisla
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var counts = new SortedDictionary<double, int>();

            foreach (var key in nums)
            {
                if (counts.ContainsKey(key))
                {
                    counts[key]++;
                }
                else
                {
                    counts[key] = 1;
                }
            }

            foreach (var key in counts.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, counts[key]);
            }
        }
    }
}
