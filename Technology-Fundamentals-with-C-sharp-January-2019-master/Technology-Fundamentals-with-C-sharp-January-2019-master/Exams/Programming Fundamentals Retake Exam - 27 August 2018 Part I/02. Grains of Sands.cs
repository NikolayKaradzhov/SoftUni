using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Grains__Of_Sands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Mort")
            {
                List<string> tokens = input.Split().ToList();
                int value = int.Parse(tokens[1]);

                if (tokens[0] == "Add")
                {
                    numbers.Add(value);
                }
                else if (tokens[0] == "Remove")
                {
                    if (numbers.Contains(value))
                    {
                        numbers.Remove(value);
                    }
                    else if (value >= 0 && value < numbers.Count)
                    {
                        numbers.RemoveAt(value);
                    }
                }
                else if (tokens[0] == "Replace")
                {
                    int replacementValue = int.Parse(tokens[2]);
                    if (numbers.Contains(value))
                    {
                        int indexOfValue = numbers.IndexOf(value);
                        numbers[indexOfValue] = replacementValue;
                    }
                }
                else if (tokens[0] == "Increase")
                {
                    int increaseValue = 0;

                    bool isElementWithNotLessValue = false;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] >= value)
                        {
                            isElementWithNotLessValue = true;
                            increaseValue = numbers[i];
                            break;
                        }
                    }
                    if (isElementWithNotLessValue == true)
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] += increaseValue;
                        }
                    }
                    else
                    {
                        int lastElemValue = numbers[numbers.Count - 1];

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] += lastElemValue;
                        }
                    }        
                }
                else if (tokens[0] == "Collapse")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < value)
                        {
                            numbers.Remove(numbers[i]);
                            i -= 1;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
