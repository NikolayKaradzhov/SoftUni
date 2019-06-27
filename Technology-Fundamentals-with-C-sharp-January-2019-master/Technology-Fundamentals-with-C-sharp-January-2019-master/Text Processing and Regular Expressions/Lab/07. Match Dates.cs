using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p07.Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})(?<groupSign>[-.\/])(?<month>[A-Z][a-z]{2})\k'groupSign'(?<year>\d{4})\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}," +
                    $" Month: {match.Groups["month"]}, " +
                    $"Year: {match.Groups["year"]}");
            }
        }
    }
}
