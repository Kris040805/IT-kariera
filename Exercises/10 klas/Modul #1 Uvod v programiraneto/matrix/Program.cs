using System;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int num = i; num <= n; num++)
                {
                    Console.Write(num + " ");
                }
                for (int num = n - 1; num >= n - i + 1; num--)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
