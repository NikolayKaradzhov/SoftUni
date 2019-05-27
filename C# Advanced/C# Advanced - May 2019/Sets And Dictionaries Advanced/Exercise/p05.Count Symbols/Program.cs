using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hashSet = new HashSet<string>();
            Dictionary<char, int> database = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var symbol in input)
            {
                if (!database.ContainsKey(symbol))
                {
                    database.Add(symbol, 1);
                }
                else
                {
                    database[symbol] += 1;
                }
            }

            var sorted = database.OrderBy(s => s.Key);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}