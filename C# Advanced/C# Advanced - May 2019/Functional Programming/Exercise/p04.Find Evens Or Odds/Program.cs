using System;
using System.Collections.Generic;
using System.Linq;

namespace p04.Find_Evens_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            List<int> numbers = new List<int>();

            string commandType = Console.ReadLine();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => 
                number % 2 == 0;

            Predicate<int> isOdd = number => 
                number % 2 != 0;

            Action<List<int>> printNumbers = outputNumbers =>
                Console.WriteLine(string.Join(" ", outputNumbers));

            if (commandType == "even")
            {
                numbers = numbers
                    .Where(x => isEven(x))
                    .ToList();
            }
            else if (commandType == "odd")
            {
                numbers = numbers
                    .Where(x => isOdd(x))
                    .ToList();
            }

            printNumbers(numbers);
        }
    }
}