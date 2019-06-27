using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^(?<peak>[A-Za-z0-9!@#\$\?]+)=(?<length>[0-9]+)<<(?<geohash>.+)";

            while (input != "Last note")
            {
                Regex order = new Regex(pattern);

                MatchCollection matches = order.Matches(input);

                StringBuilder sb = new StringBuilder();

                foreach (Match match in matches)
                {
                    string peak = match.Groups["peak"].Value;

                    foreach (var character in peak)
                    {
                        if (char.IsLetterOrDigit(character))
                        {
                            sb.Append(character);
                        }
                    }
                    string lengthString = match.Groups["length"].Value;
                    int num = 0;
                    bool lengthInteger = Int32.TryParse(lengthString, out num);
                    string geoHashCode = match.Groups["geohash"].Value;

                    if (geoHashCode.Length == num)
                    {
                        Console.WriteLine($"Coordinates found! {sb} -> {geoHashCode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                if (matches.Count == 0)
                {
                    Console.WriteLine("Nothing found!");
                }
                input = Console.ReadLine();
            }
        }
    }
}
