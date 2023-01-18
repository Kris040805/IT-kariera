using System;

namespace dograma
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            int cam = int.Parse(Console.ReadLine());
            string company = Console.ReadLine();
            double totalPrice = 0;

            double area = length * width;

            if (company == "Dogramichka4You")
            {
                if (cam == 3)
                {
                    totalPrice = area * 12;
                }
                else if (cam == 4)
                {
                    totalPrice = area * 15;
                }
                else if (cam == 5)
                {
                    totalPrice = area * 20;
                }
            }
            else if (company == "TihoToplo")
            {
                if (cam == 3)
                {
                    totalPrice = area * 15;
                }
                else if (cam == 4)
                {
                    totalPrice = area * 14;
                }
                else if (cam == 5)
                {
                    totalPrice = area * 18;
                }
            }
            else if (company == "ChukChuk")
            {
                if (cam == 3)
                {
                    totalPrice = area * 14;
                }
                else if (cam == 4)
                {
                    totalPrice = area * 20;
                }
                else if (cam == 5)
                {
                    totalPrice = area * 22;
                }
            }

            Console.WriteLine($"Goshko has to spend {totalPrice:f2} leva.");
        }
    }
}
