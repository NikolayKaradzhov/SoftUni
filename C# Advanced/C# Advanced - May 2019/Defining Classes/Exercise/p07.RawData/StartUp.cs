using System;
using System.Collections.Generic;
using System.Linq;

namespace p07.RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                Queue<string> carInfo = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

                string model = carInfo.Dequeue();
                int engineSpeed = int.Parse(carInfo.Dequeue());
                int enginePower = int.Parse(carInfo.Dequeue());
                int cargoWeight = int.Parse(carInfo.Dequeue());
                string cargoType = carInfo.Dequeue();

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                List<Tire> tireList = new List<Tire>();

                while (carInfo.Count != 0)
                {
                    double tirePressure = double.Parse(carInfo.Dequeue());
                    int tireAge = int.Parse(carInfo.Dequeue());

                    Tire tire = new Tire(tirePressure, tireAge);

                    tireList.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tireList);
                carList.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in carList.Where(x => x.Cargo.CargoType == "fragile" && x.Tire.Any(y => y.TirePressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in carList.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                } 
            }
        }
    }
}