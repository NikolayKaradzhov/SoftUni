using System;
using System.Collections.Generic;
using System.Linq;

namespace p10.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineInfoCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineInfoCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInfo[0];
                int enginePower = int.Parse(engineInfo[1]);

                //Length = 3
                //{model} {power} {displacement} {efficiency}
                string displacement = string.Empty;
                string efficiency = string.Empty;

                if (engineInfo.Length == 4)
                {
                     displacement = engineInfo[2];
                     efficiency = engineInfo[3];
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDigits = engineInfo[2].Contains('1')
                        || engineInfo[2].Contains('2')
                        || engineInfo[2].Contains('3')
                        || engineInfo[2].Contains('4')
                        || engineInfo[2].Contains('5')
                        || engineInfo[2].Contains('6')
                        || engineInfo[2].Contains('7')
                        || engineInfo[2].Contains('8')
                        || engineInfo[2].Contains('9')
                        || engineInfo[2].Contains('0');

                    if (isDigits)
                    {
                        displacement = engineInfo[2];
                        efficiency = "n/a";
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                        displacement = "n/a";
                    }
                }
                else
                {
                    displacement = "n/a";
                    efficiency = "n/a";
                }
                Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());
            string weight = string.Empty;
            string color = string.Empty;
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //"{model} {engine} {weight} {color}" - color and weight are optional

                string model = carInfo[0];
                string engineModel = carInfo[1];

                if (carInfo.Length == 4)
                {
                    weight = carInfo[2];
                    color = carInfo[3];
                }
                else if (carInfo.Length == 3)
                {
                    bool isNumeric = int.TryParse(carInfo[2], out int carWeight);

                    if (isNumeric)
                    {
                        weight = carWeight.ToString();
                        color = "n/a";
                    }
                    else
                    {
                        color = carInfo[2];
                        weight = "n/a";
                    }
                }
                else
                {
                    weight = "n/a";
                    color = "n/a";
                }
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                car.Print();
            }
        }
    }
}