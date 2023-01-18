using System;

namespace transportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();
            double taxiPrice = 0.90;

            if (dayTime == "day")
            {
                taxiPrice = 0.79;
            }

            if (n >= 100)
            {
                double totalPrice = n * 0.06;
                Console.WriteLine($"{totalPrice:F2}");
            }
            else if (n >= 20)
            {
                double totalPrice = n * 0.09;
                Console.WriteLine($"{totalPrice:F2}");
            }
            else
            {
                double totalPrice = 0.70 + n * taxiPrice;
                Console.WriteLine($"{totalPrice:F2}");
            }

        }
    }
}
