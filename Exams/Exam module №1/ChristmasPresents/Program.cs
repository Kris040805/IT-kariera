using System;

namespace ChristmasPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double pres1 = double.Parse(Console.ReadLine());

            double pres2 = 0.2 * pres1;
            double pres3 = 0.7 * pres2;
            double pres4 = 0.5 * pres2;

            double TotalPrice = pres1 + pres2 + pres3 + pres4;

            if (TotalPrice <= budget)
            {
                Console.WriteLine($"Yes! {budget - TotalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No! {TotalPrice - budget:f2} leva needed.");
            }
        }
    }
}
