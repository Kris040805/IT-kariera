using System;

namespace hotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October":

                    studioPrice = 50;
                    apartmentPrice = 65;

                    if (nights > 14)
                    {
                        studioPrice = 50 - (50 * 0.3);
                        apartmentPrice = 65 - (65 * 0.1);
                    }
                    else if (nights>7)
                    {
                        studioPrice = 50 - (50 * 0.05);
                    }
                    break;
                case "June":
                case "September":
                    
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;

                    if (nights > 14)
                    {
                        studioPrice = 75.20 - (75.20 * 0.2);
                        apartmentPrice = 68.70 - (68.70 * 0.1);
                    }
                    break;
                case "July":
                case "August":

                    studioPrice = 76;
                    apartmentPrice = 77;

                    if (nights > 14)
                    {
                        apartmentPrice = 77 - (77 * 0.1);
                    }
                    
                    break;

                   
            }

            double totalApartmentPrice = apartmentPrice * nights;
            double totalStudioPrice = studioPrice * nights;

            Console.WriteLine($"Apartment: {totalApartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:F2} lv.");
        }
    }
}
