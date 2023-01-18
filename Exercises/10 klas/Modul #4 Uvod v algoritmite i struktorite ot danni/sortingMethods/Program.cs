using System;

namespace sortingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 4, 7, 10, 1, 0 };

            BubbleSort.Sort(arr);

            Console.WriteLine(String.Join(", ", arr));
        }
    }

    public static class BubbleSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            bool swap = true;

            while (swap)
            {
                swap = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (Less(arr[i], arr[i + 1]))
                    {
                        Swap(arr, i, i + 1);
                        swap = true;
                    }
                }
            }
        }

        private static bool Less (IComparable first, IComparable second)
        {
            return first.CompareTo(second) > 0;
        }

        private static void Swap<T> (T[] collection, int from, int to)
        {
            T temp = collection[from];
            collection[from] = collection[to];
            collection[to] = temp;
        }
    }
}
