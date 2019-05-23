using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();
            HashSet<int> thirdHashSet = new HashSet<int>();

            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstHashSetLength = input[0];
            int secondHashSetLength = input[1];

            for (int i = 0; i < firstHashSetLength + secondHashSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < firstHashSetLength)
                {
                    firstHashSet.Add(number);
                }
                else
                {
                    secondHashSet.Add(number);
                }
            }
            foreach (var number in firstHashSet)
            {
                if (firstHashSet.Contains(number) && secondHashSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }   
            }
            Console.WriteLine();
        }
    }
}