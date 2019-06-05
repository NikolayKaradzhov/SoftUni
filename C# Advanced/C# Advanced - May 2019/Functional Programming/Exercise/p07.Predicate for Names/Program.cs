using System;
using System.Collections.Generic;
using System.Linq;

namespace p07.Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(n => n.Length <= length)));
        }
    }
}