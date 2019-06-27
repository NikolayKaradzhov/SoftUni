using System;
using System.Collections.Generic;
using System.Linq;

namespace p06.List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> input = command.Split().ToList();

                if (input[0] == "Add")
                {
                    int numberToAdd = int.Parse(input[1]);
                    numbers.Add(numberToAdd);
                }
                else if (input[0] == "Remove")
                {
                    int numberToRemove = int.Parse(input[1]);
                    numbers.Remove(numberToRemove);
                }
                else if (input[0] == "RemoveAt")
                {
                    int numberToRemoveAtIndex = int.Parse(input[1]);
                    numbers.RemoveAt(numberToRemoveAtIndex);
                }
                else if (input[0] == "Insert")
                {
                    int numberToInsert = int.Parse(input[1]);
                    int indexAt = int.Parse(input[2]);
                    numbers.Insert(indexAt, numberToInsert);
                }
            command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
