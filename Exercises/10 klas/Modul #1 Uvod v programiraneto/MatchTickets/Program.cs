using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            var ticketPrice = category == "VIP" ? 499.99 : 249.99;
            double moneyLeft = 0;
            
            if (people >= 1 && people <=4)
            {
                moneyLeft = budget - (0.75 * budget);
            }
            else if (people >= 5 && people <= 9)
            {
                moneyLeft = budget - (0.6 * budget);
            }
            else if (people >= 10 && people <= 24)
            {
                moneyLeft = budget - (0.5 * budget);
            }
            else if (people >= 25 && people <= 49)
            {
                moneyLeft = budget - (0.4 * budget);
            }
            else
            {
                moneyLeft = budget - (0.25 * budget);
            }

            double TotalTicketPrice = people * ticketPrice;

            if (TotalTicketPrice > moneyLeft)
            {
                Console.WriteLine($"Not enough money! You need {TotalTicketPrice - moneyLeft:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {moneyLeft - TotalTicketPrice:F2} leva left.");
            }
        }
    }
}
