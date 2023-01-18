using System;

namespace delenieBezOstatak
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int Sum = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                int a= int.Parse(Console.ReadLine());
                Sum = Sum + a;
                if (a > max)
                {
                    max = a;
                }
                
            }
            
            Sum = Sum - max;
            if (Sum == max)
            {
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                Console.WriteLine("Diff = " + Math.Abs(max-Sum));
            }
        }
    }
}
