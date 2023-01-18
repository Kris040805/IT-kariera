using System;

namespace winningNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i <= 9; i++)
            {
                for (int a = 0; a <= 9; a++)
                {
                    for (int b = 0; b <= 9; b++)
                    {
                        for (int c = 0; c <= 9; c++)
                        {
                            if (i + c == N  &&  a % 2 != 0  &&  (b == 4  ||  b == 7))
                            {
                                Console.Write($"{i}{a}{b}{c} ");
                            }                                                
                        }
                    }
                }
            }
        }
    }
}
