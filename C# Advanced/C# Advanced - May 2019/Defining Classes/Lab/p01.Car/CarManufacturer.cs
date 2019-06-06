using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.Make = "BMW";
            myCar.Model = "M5 Competition";
            myCar.Year = 2018;
            myCar.FuelQuantity = 54;
            myCar.FuelConsumption = 12;

            Console.Write($"Make: {myCar.Make}{Environment.NewLine}" +
                $"Model: {myCar.Model}{Environment.NewLine}" +
                $"Year: {myCar.Year}{Environment.NewLine}");

            myCar.Drive(143);

            Console.WriteLine(myCar.WhoAmI());
        }
    }
}