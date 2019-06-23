using System;
using System.Collections.Generic;
using System.Linq;

namespace p01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chemicalLiquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] physicalItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int glassMadeCount = 0;
            int aluminiumMadeCount = 0;
            int carbonFiberMadeCount = 0;
            int lithiumMadeCount = 0;

            List<int> chemicalsList = new List<int>(chemicalLiquids);

            Stack<int> physicalItemsStack = new Stack<int>(physicalItems);

            while (physicalItemsStack.Count != 0 && chemicalsList.Count != 0)
            {
                int currentChemical = chemicalsList[0];
                int currentPhysicalItem = physicalItemsStack.Pop();

                int sum = currentChemical + currentPhysicalItem;

                if (sum == 25)
                {
                    glassMadeCount++;

                    chemicalsList.RemoveAt(0);
                }
                else if (sum == 50)
                {
                    aluminiumMadeCount++;

                    chemicalsList.RemoveAt(0);
                }
                else if (sum == 75)
                {
                    lithiumMadeCount++;

                    chemicalsList.RemoveAt(0);
                }
                else if (sum == 100)
                {
                    carbonFiberMadeCount++;

                    chemicalsList.RemoveAt(0);
                }
                else
                {
                    chemicalsList.RemoveAt(0);

                    currentPhysicalItem += 3;
                    physicalItemsStack.Push(currentPhysicalItem);
                }
            }

            if (glassMadeCount > 0 && lithiumMadeCount > 0 && carbonFiberMadeCount > 0 && aluminiumMadeCount > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalsList.Count == 0)
            {
                Console.WriteLine($"Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", chemicalsList)}");
            }

            if (physicalItemsStack.Count == 0)
            {
                Console.WriteLine($"Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItemsStack)}");
            }

            Console.WriteLine($"Aluminium: {aluminiumMadeCount}");
            Console.WriteLine($"Carbon fiber: {carbonFiberMadeCount}");
            Console.WriteLine($"Glass: {glassMadeCount}");
            Console.WriteLine($"Lithium: {lithiumMadeCount}");
        }
    }
}