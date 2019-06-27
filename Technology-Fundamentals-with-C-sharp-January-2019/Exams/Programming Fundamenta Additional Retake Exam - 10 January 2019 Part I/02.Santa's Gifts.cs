using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Santa_s_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int santaCurrentPositionIndex = 0;

            for (int h = 0; h < numberOfCommands; h++)
            {
                string command = Console.ReadLine();
                List<string> tokens = command.Split().ToList();

                string step = tokens[0];
                int jump = int.Parse(tokens[1]);

                if (step == "Forward")
                {
                    if (jump < 0 || jump + santaCurrentPositionIndex >= numbers.Count)
                    {
                        continue;
                    }
                    for (int i = santaCurrentPositionIndex; i < numbers.Count; i++)
                    {
                        if (santaCurrentPositionIndex + jump == i)
                        {
                            numbers.RemoveAt(i);
                            santaCurrentPositionIndex = i;
                            break;
                        }
                    }
                }
                else if (step == "Back")
                {
                    if (santaCurrentPositionIndex - jump < 0)
                    {
                        continue;
                    }
                    for (int j = santaCurrentPositionIndex; j >= 0; j--)
                    {
                        if (santaCurrentPositionIndex - jump == j)
                        {
                            numbers.RemoveAt(j);
                            santaCurrentPositionIndex = j;
                            break;
                        }
                    }
                }
                else if (step == "Gift")
                {
                    int giftIndex = int.Parse(tokens[1]);
                    int houseNumber = int.Parse(tokens[2]);
                    if (giftIndex < 0 || giftIndex >= numbers.Count)
                    {
                        continue;
                    }
                    numbers.Insert(giftIndex, houseNumber);
                    santaCurrentPositionIndex = giftIndex;
                }
                else if (step == "Swap")
                {
                    int valueOne = int.Parse(tokens[1]);
                    int valueTwo = int.Parse(tokens[2]);
                    int temp = valueOne;
                    int indexOfValueOne = numbers.IndexOf(valueOne);
                    int indexOfValueTwo = numbers.IndexOf(valueTwo);

                    if (numbers.Contains(valueOne) && numbers.Contains(valueTwo))
                    {
                        numbers[indexOfValueOne] = valueTwo;
                        numbers[indexOfValueTwo] = valueOne;
                    }
                }
            }
            Console.WriteLine($"Position: {santaCurrentPositionIndex}");
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
