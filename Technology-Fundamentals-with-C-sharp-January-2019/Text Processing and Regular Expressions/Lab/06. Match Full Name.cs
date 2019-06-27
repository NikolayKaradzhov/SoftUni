using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p06.Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> splittedInput = input.Split(", ").ToList();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection names = Regex.Matches(input, pattern);

            foreach (var name in names)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}
