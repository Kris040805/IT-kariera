using System;
using System.Collections.Generic;
using System.Linq;

namespace chisla_kvadrati
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> squares = new List<int>();
            //numbers.Sort();
            //numbers.Reverse();

            foreach (var number in numbers)
            {
                if (Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    squares.Add(number);
                }
            }
            squares.Sort();
            Console.WriteLine(string.Join(" ", squares));
        }
    }
}
