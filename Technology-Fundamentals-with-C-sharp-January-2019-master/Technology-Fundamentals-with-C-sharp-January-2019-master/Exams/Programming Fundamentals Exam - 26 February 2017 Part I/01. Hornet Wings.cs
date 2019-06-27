using System;

namespace p01.Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            decimal distanceInMeters = decimal.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            decimal distance = (wingFlaps / 1000) * distanceInMeters;

            int seconds = wingFlaps / 100;

            int time = ((wingFlaps / endurance) * 5) + seconds;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{time} s.");
        }
    }
}
