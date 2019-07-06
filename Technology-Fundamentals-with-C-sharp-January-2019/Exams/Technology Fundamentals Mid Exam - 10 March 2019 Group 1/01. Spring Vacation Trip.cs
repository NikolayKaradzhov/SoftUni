using System;

namespace p01.Spring_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double daysOfTrip = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double people = double.Parse(Console.ReadLine());
            double fuelPerKM = double.Parse(Console.ReadLine());
            double foodExpensesPerPerson = double.Parse(Console.ReadLine());
            double roomPricePerNight = double.Parse(Console.ReadLine());

            double totalFoodExpenses = people * foodExpensesPerPerson * daysOfTrip;

            double priceHotelForAllNights = roomPricePerNight * people * daysOfTrip;

            if (people > 10)
            {
                priceHotelForAllNights -= priceHotelForAllNights * 0.25;
            }
            else
            {
                priceHotelForAllNights = roomPricePerNight * people * daysOfTrip;
            }
            double totalCurrentExpenses = totalFoodExpenses + priceHotelForAllNights;

            double fuelExpenses = 0.0;

            for (int i = 1; i <= daysOfTrip; i++)
            {
                double travelledDistanceInKMPerDay = double.Parse(Console.ReadLine());

                fuelExpenses = travelledDistanceInKMPerDay * fuelPerKM;

                totalCurrentExpenses += fuelExpenses;

                if (i % 5 == 0 || i % 3 == 0)
                {
                    totalCurrentExpenses = totalCurrentExpenses + (totalCurrentExpenses * 0.4);
                }
                if (i % 7 == 0)
                {
                    totalCurrentExpenses = totalCurrentExpenses - (totalCurrentExpenses / people);
                }
                
                if (totalCurrentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {Math.Abs(totalCurrentExpenses- budget):f2}$ more.");
                    break;
                }
            }
            double endBudget = Math.Abs(totalCurrentExpenses - budget);
            if (totalCurrentExpenses <= budget)
            {
                Console.WriteLine($"You have reached the destination. You have {endBudget:f2}$ budget left.");
            }
        }
    }
}
