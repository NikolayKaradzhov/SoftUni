using System;

namespace p04.Centuries_To_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            int centuriesToYearsConverted = centuries * 100;

            int yearsToDaysConverted = (int) (centuriesToYearsConverted * 365.2422);

            int daysToHoursConverted = yearsToDaysConverted * 24;

            int hoursToMinutesConverted = daysToHoursConverted * 60;

            Console.WriteLine($"{centuries} centuries = " +
                $"{centuriesToYearsConverted} years = " +
                $"{yearsToDaysConverted} days = " +
                $"{daysToHoursConverted} hours = " +
                $"{hoursToMinutesConverted} minutes");
        }
    }
}
