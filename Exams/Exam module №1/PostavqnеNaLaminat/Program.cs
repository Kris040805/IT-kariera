using System;

namespace PostavqnaNaLaminat
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceLaminate = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double pricePad = double.Parse(Console.ReadLine());

            double roomArea = lenght * width;
            double TotalLamPrice = roomArea * priceLaminate;
            double TotalPadPrice = roomArea * pricePad;
            double work = 0.4 * (TotalLamPrice + TotalPadPrice);
            double allPrice = TotalPadPrice + TotalLamPrice + work;
            Console.WriteLine(Math.Round((allPrice),2));
        }
    }
}
