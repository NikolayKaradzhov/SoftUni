using System;
using System.Linq;

namespace p01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}