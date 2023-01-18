using System;

namespace sleepyTom
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());
            int workingDays = 365 - freeDays;
            int playTime = workingDays * 63 + freeDays * 127;

            int difference = playTime - 30000;
            int hours = Math.Abs(difference / 60);
            int minutes = Math.Abs(difference % 60);
            
            if (playTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }

        }
    }
}
