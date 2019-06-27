using System;
using System.Collections.Generic;
using System.Linq;

namespace p07.List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isChanged = false;

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> input = command.Split().ToList();

                if (input[0] == "Add")
                {
                    int numberToAdd = int.Parse(input[1]);
                    numbers.Add(numberToAdd);
                    isChanged = true;
                }
                else if (input[0] == "Remove")
                {
                    int numberToRemove = int.Parse(input[1]);
                    numbers.Remove(numberToRemove);
                    isChanged = true;
                }
                else if (input[0] == "RemoveAt")
                {
                    int numberToRemoveAtIndex = int.Parse(input[1]);
                    numbers.RemoveAt(numberToRemoveAtIndex);
                    isChanged = true;
                }
                else if (input[0] == "Insert")
                {
                    int numberToInsert = int.Parse(input[1]);
                    int indexAt = int.Parse(input[2]);
                    numbers.Insert(indexAt, numberToInsert);
                    isChanged = true;
                }

                if (input[0] == "Contains")
                {
                    int currentNumber = int.Parse(input[1]);
                    if (numbers.Contains(currentNumber))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (input[0] == "PrintEven")
                {
                    List<int> printEven = numbers.Where(x => x % 2 == 0).ToList();

                    Console.WriteLine(string.Join(" ", printEven));
                }
                else if (input[0] == "PrintOdd")
                {
                    List<int> printOdd = numbers.Where(x => x % 2 == 1).ToList();

                    Console.WriteLine(string.Join(" ", printOdd));
                }
                else if (input[0] == "GetSum")
                {
                    int sumOfAllNumbers = 0;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sumOfAllNumbers += numbers[i];
                    }
                    Console.WriteLine(sumOfAllNumbers);
                }
                else if (input[0] == "Filter")
                {
                    string condition = input[1];
                    int number = int.Parse(input[2]);

                    if (condition == "<")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < number)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (condition == ">")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > number)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (condition == "<=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= number)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (condition == ">=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= number)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                command = Console.ReadLine();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
