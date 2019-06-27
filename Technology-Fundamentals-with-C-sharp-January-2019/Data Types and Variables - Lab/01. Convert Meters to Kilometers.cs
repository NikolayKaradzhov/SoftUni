using System;

namespace p01.Convert_meters_to_kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int metersDistance = int.Parse(Console.ReadLine());

            double resultInKilometers = metersDistance / 1000.00;

            Console.WriteLine($"{resultInKilometers:F2}");
        }
    }
}
