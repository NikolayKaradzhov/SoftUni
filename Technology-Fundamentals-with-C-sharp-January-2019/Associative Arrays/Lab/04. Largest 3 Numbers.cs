using System;
using System.Collections.Generic;
using System.Linq;

namespace p04.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedNumbersInput = Console.ReadLine().Split(" ")
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3);

            foreach (var number in sortedNumbersInput)
            {
                Console.Write(number + " ");
            }
        }
    }
}
