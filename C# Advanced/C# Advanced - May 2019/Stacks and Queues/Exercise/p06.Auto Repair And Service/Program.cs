using System;
using System.Collections.Generic;

namespace p06.Auto_Repair_And_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carsInput = Console.ReadLine().Split(" ");

            string command = Console.ReadLine();

            Queue<string> queue = new Queue<string>(carsInput);
            Stack<string> servedVehiclesList = new Stack<string>();

            while (command != "End")
            {
                if (command == "Service" && queue.Count > 0)
                {
                    var currentVehicle = queue.Dequeue();
                    Console.WriteLine($"Vehicle {currentVehicle} got served.");
                    servedVehiclesList.Push(currentVehicle);
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedVehiclesList));
                }
                else if (command.Contains("CarInfo"))
                {
                    string[] tokens = command.Split('-');
                    string car = tokens[1];

                    if (queue.Contains(car))
                    {
                        Console.WriteLine($"Still waiting for service.");
                    }
                    else if (!queue.Contains(car))
                    {
                        Console.WriteLine("Served.");
                    }
                }
                command = Console.ReadLine();
            }
            if (queue.Count > 0)
            {
                Console.Write("Vehicles for service: ");
                Console.Write(string.Join(", ", queue));
                Console.WriteLine();
            }

            Console.Write("Served vehicles: ");
            Console.Write(string.Join(", ", servedVehiclesList));

            Console.WriteLine();
        }
    }
}