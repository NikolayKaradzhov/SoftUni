using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string instructions = Console.ReadLine();

            while (instructions != "END")
            {
                List<string> tokens = instructions.Split(" ").ToList();
 
                if (tokens[0] == "Change")
                {
                    int paintingNumber = int.Parse(tokens[1]);
                    int changedNumber = int.Parse(tokens[2]);

                    if (numbers.Contains(paintingNumber))
                    {
                        int indexOfPaintingNumber = numbers.IndexOf(paintingNumber);

                        numbers[indexOfPaintingNumber] = changedNumber;
                    }
                }
                else if (tokens[0] == "Hide")
                {
                    int value = int.Parse(tokens[1]);
                    if (numbers.Contains(value))
                    {
                        numbers.Remove(value);
                    }
                }
                else if (tokens[0] == "Switch")
                {
                    int firstPaintingSwitch = int.Parse(tokens[1]);
                    int secondPaintingSwitch = int.Parse(tokens[2]);
                    int temp = firstPaintingSwitch;
                    
                    if (numbers.Contains(firstPaintingSwitch) && numbers.Contains(secondPaintingSwitch))
                    {
                        int firtPaintingIndex = numbers.IndexOf(firstPaintingSwitch);
                        int secondPaintingIndex = numbers.IndexOf(secondPaintingSwitch);
                        numbers[firtPaintingIndex] = secondPaintingSwitch;
                        numbers[secondPaintingIndex] = temp;
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    int placeIndex = int.Parse(tokens[1]);
                    int givenNumber = int.Parse(tokens[2]);

                    if (placeIndex >= 0 && placeIndex < numbers.Count)
                    {
                        numbers.Insert(placeIndex + 1, givenNumber);
                    }
                }
                else if (tokens[0] == "Reverse")
                {
                    numbers.Reverse();
                }
                instructions = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
