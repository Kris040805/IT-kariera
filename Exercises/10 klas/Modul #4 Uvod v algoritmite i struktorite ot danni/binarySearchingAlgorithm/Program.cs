using System;

namespace binarySearchingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 2, 4, 8, -1, 9, 0, -7, 16 };

            Array.Sort(array);

            Console.WriteLine(BinarySearch(array, 8, 0, array.Length - 1));
        }

        private static int BinarySearch(int[] arr, int key, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (arr[mid] > key)
            {
                BinarySearch(arr, key, start, mid - 1);
            }
            else if (arr[mid] < key)
            {
                BinarySearch(arr, key, mid + 1, end);
            }

            return mid;
        }
    }
}
