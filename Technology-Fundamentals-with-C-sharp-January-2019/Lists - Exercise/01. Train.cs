using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int capacityOfEachWagon = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> updatedWagons = command.Split().ToList();

                if (updatedWagons.Count == 2)
                {
                    int peopleInWagons = int.Parse(updatedWagons[1]);
                    listOfWagons.Add(peopleInWagons);
                }
                else
                {
                    int passangersToGetIn = int.Parse(updatedWagons[0]);

                    for (int i = 0; i < listOfWagons.Count; i++)
                    {
                        if (listOfWagons[i] + passangersToGetIn <= capacityOfEachWagon)
                        {
                            listOfWagons[i] += passangersToGetIn;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in listOfWagons)
            {
                Console.Write(item + " ");
            }
        }
    }
}
