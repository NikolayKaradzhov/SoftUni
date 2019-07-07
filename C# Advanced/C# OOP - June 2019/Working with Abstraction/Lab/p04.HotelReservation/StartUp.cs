using System;
using System.Collections.Generic;
using System.Linq;

namespace p04.HotelReservation
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> inputParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double pricePerDay = double.Parse(inputParameters[0]);
            int numberOfDays = int.Parse(inputParameters[1]);
            Season season = (Season)Enum.Parse(typeof(Season), inputParameters[2]);
            DiscountType discountType = DiscountType.None;

            if (inputParameters.Count == 4)
            {
                discountType = (DiscountType) Enum.Parse(typeof(DiscountType), inputParameters[3]);
            }

            PriceCalculator priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine($"{priceCalculator.CalculatePrice():F2}");
        }
    }
}