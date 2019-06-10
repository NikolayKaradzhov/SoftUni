using System;
using System.Collections.Generic;

namespace p06.SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsInput = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = carsInput[0];
                double fuelAmount = double.Parse(carsInput[1]);
                double fuelConsumptionFor1Km = double.Parse(carsInput[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);

                carList.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                double amountOfKilometers = double.Parse(tokens[2]);
                int indexOfCurrentCar = carList.IndexOf(carList.Find(x => x.Model == carModel));

                carList[indexOfCurrentCar].Drive(amountOfKilometers);

                input = Console.ReadLine();
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Distance}");
            }
        }
    }
}