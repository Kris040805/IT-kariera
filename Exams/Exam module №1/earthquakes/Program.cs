using System;

namespace earthquakes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int Light = 0;
            int Moderate = 0;
            int Strong = 0;
            int VeryStrong = 0;

            for (int i = 0; i < n; i++)
            {
                double bum = double.Parse(Console.ReadLine());

                if (bum >=0 && bum <= 4)
                {
                    Light++;
                }
                else if (bum >4 && bum <= 6)
                {
                    Moderate++;
                }
                else if (bum > 6 && bum <= 7)
                {
                    Strong++;
                }
                else 
                {
                    VeryStrong++;
                }
            }

            double pLight = ((Light*1.0) / n) * 100;
            double pModerate = ((Moderate*1.0) / n) * 100;
            double pStrong = ((Strong*1.0)  / n) * 100;
            double pVeryStrong = ((VeryStrong*1.0) / n) * 100;

            Console.WriteLine($"Light: {pLight:f2}%");
            Console.WriteLine($"Moderate: {pModerate:f2}%");
            Console.WriteLine($"Strong: {pStrong:f2}%");
            Console.WriteLine($"Very Strong: {pVeryStrong:f2}%");
        }
    }
}
