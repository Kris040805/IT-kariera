using System;
using System.Collections.Generic;
using System.Linq;

namespace sortingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();

            Sort(list);
            Console.WriteLine(String.Join(", ", list));
        }

        private static void Sort(List<string> list)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        string curr = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = curr;
                    }
                }
                
            }
        }
    }
}
