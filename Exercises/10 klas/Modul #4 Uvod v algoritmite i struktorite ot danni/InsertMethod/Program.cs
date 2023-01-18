using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(", ", arr));
            Console.WriteLine(String.Join(", ", Insert(arr, num)));
        }

        private static int[] Insert(int[] arr, int num)
        {
            int[] arr2 = new int[arr.Length + 1];
            int position = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (num > arr[i] && num < arr[i + 1])
                {
                    position = i + 1;
                }
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                if (i < position)
                {
                    arr2[i] = arr[i];
                }
                else if (i == position)
                {
                    arr2[i] = num;
                }
                else
                {
                    arr2[i] = arr[i - 1];
                }
            }

            return arr2;
        }
    }
}
