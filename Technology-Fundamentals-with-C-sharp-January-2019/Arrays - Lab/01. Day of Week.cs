using System;

namespace Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayRead = int.Parse(Console.ReadLine());

            if (dayRead < 1 || dayRead > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysOfWeek[dayRead - 1]);
            }
        }
    }
}
