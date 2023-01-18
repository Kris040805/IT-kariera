using System;

namespace binaryAritmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string resultN = "";

            while (n > 0)
            {
                resultN += n % 2;
                n /= 2;
            }

            for (int i = resultN.Length - 1; i >= 0; i--)
            {
                Console.Write(resultN[i]);
            }

            Console.WriteLine();
        }
    }
}
