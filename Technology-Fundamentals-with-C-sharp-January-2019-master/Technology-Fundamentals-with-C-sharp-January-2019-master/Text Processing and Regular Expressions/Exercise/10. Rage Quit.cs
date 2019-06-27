using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p10.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<message>[^0-9]+)(?<times>\d+)";
            Regex order = new Regex(pattern);
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            string stringToPrint = string.Empty;

            foreach (Match matches in match)
            {
                if (order.IsMatch(matches.ToString()))
                {
                    string messageToRepeat = order.Match(matches.ToString()).Groups["message"].Value;
                    int timesToRepeat = int.Parse(order.Match(matches.ToString()).Groups["times"].Value);

                    foreach (var character in messageToRepeat)
                    {
                        result += Char.ToUpper(character);
                    }
                    for (int i = 0; i < timesToRepeat; i++)
                    {
                        sb.Append(result);
                    }
                    result = string.Empty;
                }
            }
            stringToPrint = sb.ToString();
            int countUniqueSymbols = stringToPrint.Distinct().Count();
            Console.WriteLine($"Unique symbols used: {countUniqueSymbols}");
            Console.WriteLine(sb);
        }
    }
}
