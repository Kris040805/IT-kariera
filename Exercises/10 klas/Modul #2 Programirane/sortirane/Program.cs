using System;
using System.Linq;

namespace sortirane
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j]; ;
                        a[j] = temp;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", a));
        }
    }
}
