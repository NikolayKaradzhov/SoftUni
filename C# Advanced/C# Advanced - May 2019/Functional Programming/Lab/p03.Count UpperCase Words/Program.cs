using System;
using System.Linq;

namespace p03.Count_UpperCase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}