using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houseWithNumberOfMembers = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();

            int fieldSize = houseWithNumberOfMembers.Count();
            int currentPosition = 0;
            int completedHouses = 0;
            int failedHouses = fieldSize;
            string input = Console.ReadLine();

            while (input != "Merry Xmas!")
            {
                List<string> command = input.Split(" ").ToList();
                int jumpLength = int.Parse(command[1]);

                for (int i = currentPosition; i <= fieldSize; i++)
                {

                    if (jumpLength + currentPosition >= fieldSize)
                    {
                        currentPosition = (currentPosition + jumpLength) % fieldSize;
                        if (houseWithNumberOfMembers[currentPosition] == 0)
                        {
                            Console.WriteLine($"House {currentPosition} will have a Merry Christmas.");
                            break;
                        }
                        else
                        {
                            houseWithNumberOfMembers[currentPosition] -= 2;
                            break;
                        }
                    }
                    else
                    {
                        currentPosition += jumpLength;

                        if (houseWithNumberOfMembers[currentPosition] == 0)
                        {
                            Console.WriteLine($"House {currentPosition} will have a Merry Christmas.");
                            break;
                        }
                        else
                        {
                            houseWithNumberOfMembers[currentPosition] -= 2;
                            break;
                        }
                    }

                }

                input = Console.ReadLine();
            }
            if (houseWithNumberOfMembers.Sum() == 0)
            {
                Console.WriteLine($"Santa's last position was {currentPosition}.");
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    if (houseWithNumberOfMembers[i] == 0)
                    {
                        completedHouses++;
                    }
                }
                failedHouses -= completedHouses;
                Console.WriteLine($"Santa's last position was {currentPosition}.");
                Console.WriteLine($"Santa has failed {failedHouses} houses.");
            }
        }
    }
}
