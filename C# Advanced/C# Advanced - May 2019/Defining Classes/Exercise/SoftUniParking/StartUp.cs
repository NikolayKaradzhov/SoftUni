using System;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var parking = new Parking(0);

            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            System.Console.WriteLine(car.ToString());

            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car));

            Console.WriteLine(parking.RemoveCar("CC1856BG"));

            Console.WriteLine(parking.Count);

        }
    }
}