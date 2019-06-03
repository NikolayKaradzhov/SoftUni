using System;
using System.Linq;

namespace p02.Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(Parse)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());

        }
        public static Func<string, int> Parse = n => int.Parse(n);
    }
}