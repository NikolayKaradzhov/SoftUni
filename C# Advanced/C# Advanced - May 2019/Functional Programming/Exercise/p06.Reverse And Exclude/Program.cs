using System;
using System.Collections.Generic;
using System.Linq;

namespace p06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int divisionNumber = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (number, division)
               => number % division == 0;

            Action<int[]> printReverse = numbersToPrint
                => Console.WriteLine(string.Join(" ", numbersToPrint.Reverse()));

            List<int> printNumbers = new List<int>(numbers);

            foreach (var number in numbers)
            {
                if (isDivisible(number, divisionNumber))
                {
                    printNumbers.Remove(number);
                } 
            }

            printReverse(printNumbers.ToArray());
        }
    }
}