using System;
using System.Collections.Generic;
using System.Linq;

namespace p07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumpsCount = int.Parse(Console.ReadLine());

            var fuelPump = new Queue<int[]>();

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                fuelPump.Enqueue(tokens);               
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in fuelPump)
                {
                    int petrolAmount = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += petrolAmount - distance;

                    if (totalFuel < 0)
                    {
                        fuelPump.Enqueue(fuelPump.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}