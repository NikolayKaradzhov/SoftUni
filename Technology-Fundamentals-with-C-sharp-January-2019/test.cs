using System;
using System.Text.RegularExpressions;

namespace p01._Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string currentWord = string.Empty;

            bool firstPartIsTrue = false;

            string[] separated = input.Split("|");

            for (int i = 0; i < 1; i++)
            {
                string pattern = @"(?<g>[#%&*$][A-Z]+[#%&*$])";
                Regex order = new Regex(pattern);

                MatchCollection matches = order.Matches(separated[0]);

                foreach (Match match in matches)
                {
                    string currentString = match.Groups["g"].Value;
                    char currentFirstSymbol = currentString[0];
                    char currentLastSymbol = currentString[currentString.Length - 1];
                    currentWord = currentString.Substring(1, currentString.Length - 2);

                    if (currentFirstSymbol == currentLastSymbol && currentWord.Length >= 1)
                    {
                        firstPartIsTrue = true;
                    }
                }
            }

            for (int i = 0; i < 1; i++)
            {

            }               
        }
    }
}
