using System;
using System.Collections.Generic;

namespace nameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            string currentName = Console.ReadLine();
            while (currentName != "END OF GAME")
            {
                names.Add(currentName);
                currentName = Console.ReadLine();
            }

            int max = 0;
            string winnerName = "";

            foreach (var name in names)
            {
                int pointsOfCurrentName = 0;

                if (name.EndsWith('a'))
                {
                    pointsOfCurrentName += 10;
                }
                if (name.EndsWith('v'))
                {
                    pointsOfCurrentName += 13;
                }
                if (name.Length >= 7)
                {
                    pointsOfCurrentName += 33;
                }
                else
                {
                    pointsOfCurrentName += 22;
                }

                if (pointsOfCurrentName > max)
                {
                    max = pointsOfCurrentName;
                    winnerName = name;
                }
            }
            Console.WriteLine($"Winner is name: {winnerName}");
            Console.WriteLine($"Points: {max}");
        }
    }
}
