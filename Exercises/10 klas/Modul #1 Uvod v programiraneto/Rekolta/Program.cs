using System;

namespace Rekolta
{
    class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapePERsquare = double.Parse(Console.ReadLine());
            int wineNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grape = area * grapePERsquare;
            double wine = 0.4 * grape / 2.5;

            if (wine < wineNeeded)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeeded - wine)} liters wine needed.");
            }
            else
            {
                double WinePerWorker = (wine - wineNeeded) / workers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(wine - wineNeeded)} liters left -> {Math.Ceiling(WinePerWorker)} liters per person.");
            }
        }
    }
}
