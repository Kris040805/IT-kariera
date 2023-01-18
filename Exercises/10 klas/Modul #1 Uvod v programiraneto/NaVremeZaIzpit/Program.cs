using System;

namespace NaVremeZaIzpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int hhExam = int.Parse(Console.ReadLine());
            int mmExam = int.Parse(Console.ReadLine());
            int hhArrival = int.Parse(Console.ReadLine());
            int mmArrival = int.Parse(Console.ReadLine());

            int examTime = hhExam * 60 + mmExam;
            int arrivalTime = hhArrival * 60 + mmArrival;
            int minutesDifference = arrivalTime - examTime;

            if (minutesDifference < -30)
            {
                Console.WriteLine("Early");
            }
            else if (minutesDifference <=0)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Late");
            }

            if (minutesDifference != 0)
            {
                var Hours = Math.Abs(minutesDifference / 60);
                var Minutes = Math.Abs(minutesDifference % 60);

                if (Hours > 0)
                {
                    if (Minutes < 10)
                        Console.Write(Hours + ":0" + Minutes + " hours");
                    else
                        Console.Write(Hours + ":" + Minutes + " hours");
                }
                else
                    Console.Write(Minutes + " minutes");
                if (minutesDifference < 0)
                    Console.WriteLine(" before the start");
                else
                    Console.WriteLine(" after the start");
            }

        }
    }
    
}
