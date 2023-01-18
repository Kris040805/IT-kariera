using System;
using System.Linq;

namespace tarsene_na_elem_v_sort_masiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (n == arr[i])
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine(found ? "Yes" : "No");
        }
    }
}
