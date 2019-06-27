using System;
using System.Text.RegularExpressions;

namespace p08.Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(^|(?<=\s))-?[0-9]+(\.[0-9]+)?($|(?=\s))");

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
            Console.WriteLine();
        }
    }
}
