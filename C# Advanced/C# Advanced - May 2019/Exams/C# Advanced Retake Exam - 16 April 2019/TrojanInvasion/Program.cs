using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfTrojanWarriors = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> warriors = new Stack<int>();

            for (int i = 1; i <= wavesOfTrojanWarriors; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                warriors = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    plates.Add(additionalPlate);
                }

                while (warriors.Count != 0 && plates.Count != 0)
                {
                    int warrior = warriors.Pop();
                    int plate = plates[0];

                    if (warrior > plate)
                    {
                        warrior -= plate;
                        warriors.Push(warrior);
                        plates.RemoveAt(0);
                    }
                    else if (plate > warrior)
                    {
                       plates[0] = plate - warrior;
                    }
                    else if (plate == warrior)
                    {
                        plates.RemoveAt(0);
                    }
                }
            }

            if (plates.Count != 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
        }
    }
}