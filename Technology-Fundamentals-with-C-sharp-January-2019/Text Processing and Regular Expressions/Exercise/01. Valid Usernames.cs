using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p01.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^(\w|-){3,16}$";
            var matches = Regex.Matches(input, pattern);

            List<string> namesSplitted = input.Split(", ").ToList();

            foreach (var name in namesSplitted)
            {
                matches = Regex.Matches(name, pattern);
                if (matches.Count > 0)
                {
                    Console.WriteLine(matches[0]);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
