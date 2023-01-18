using System;
using System.Collections.Generic;
using System.Linq;

namespace passStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> playerStats = new SortedDictionary<string, int>();
            
            string currentPlayer = Console.ReadLine();
            while (currentPlayer != "End of match")
            {
                string[] playerPass = currentPlayer.Split(" - ").ToArray();
                string playerName = playerPass[0];
                int playerPasses = int.Parse(playerPass[1]);

                if (!playerStats.ContainsKey(playerName))
                {
                    playerStats.Add(playerName, playerPasses);
                }
                else
                {
                    playerStats[playerName] += playerPasses;
                }
                
                currentPlayer = Console.ReadLine();
            }

            foreach (var pair in playerStats)
            {
                Console.WriteLine($"{pair.Key} has passed {pair.Value} passes.");
            }
        }
    }
}
