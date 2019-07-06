using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
               string[] tokens = command.Split();

                if (tokens[0] == "Delete")
                {
                    int elementToRemove = int.Parse(tokens[1]);
                    //Remove all elements = tokens[1]
                    nums.RemoveAll(element => element == elementToRemove);
                }
                else if (tokens[0] == "Insert")
                {
                    //Insert 10-number 1-position(index)
                    int elementToInsert = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    nums.Insert(position, elementToInsert);
                }
            command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
