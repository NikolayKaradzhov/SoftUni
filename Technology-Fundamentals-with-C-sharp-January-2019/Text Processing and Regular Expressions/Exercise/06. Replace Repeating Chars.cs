using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p06.Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            List<char> result = new List<char>();

            result.Add(input[0]);

            foreach (var symbol in input)
            {
                if (symbol != result.Last())
                {
                    result.Add(symbol);
                }
            }
            Console.WriteLine(string.Join(string.Empty, result));
        }
    }
}
