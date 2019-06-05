using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<int> numbers = Enumerable.Range(1, upperBound).ToList();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var currentNumber in dividers)
            {
                predicates.Add(x => x % currentNumber == 0);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isValid = true;

                foreach (var currentPredicate in predicates)
                {
                    if (!currentPredicate(numbers[i]))
                    {
                        numbers.Remove(numbers[i]);
                        i--;
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}