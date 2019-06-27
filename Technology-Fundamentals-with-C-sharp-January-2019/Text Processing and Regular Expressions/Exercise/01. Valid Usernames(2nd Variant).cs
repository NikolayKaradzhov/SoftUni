using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p01.Valid_Usernames_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> names = input.Split(", ").ToList();

            foreach (var name in names)
            {
                bool isValid = name.All(c => Char.IsLetterOrDigit(c) || c.Equals('_') || c.Equals('-'));

                if ((name.Length >= 3 && name.Length <= 16) && (isValid))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
