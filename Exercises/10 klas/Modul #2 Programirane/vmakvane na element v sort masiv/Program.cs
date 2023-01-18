   using System;
using System.Linq;

namespace vmakvane_na_element_v_sort_masiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            int[] arr2 = new int[arr1.Length + 1];
            int placed = 0;

            for (int i = 0; i < arr2.Length; i++)
            {
                if (number >= arr1[i - placed] || placed == 1)
                {
                    arr2[i] = arr1[i - placed];
                }
                else
                {
                    arr2[i] = number;
                    placed = 1;
                }
            }
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
