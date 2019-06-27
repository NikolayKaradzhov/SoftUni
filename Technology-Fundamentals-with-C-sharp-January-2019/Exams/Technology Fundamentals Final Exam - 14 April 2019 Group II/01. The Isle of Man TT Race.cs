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

            string pattern = @"(?<racer>[A-Za-z#*$%&]+)=(?<length>[0-9]+)!!(?<geohash>.+)";

            while (true)
            {
                Regex order = new Regex(pattern);

                MatchCollection matches = order.Matches(input);

                foreach (Match match in matches)
                {
                    string racer = match.Groups["racer"].Value;
                    string lengthString = match.Groups["length"].Value;
                    int num = 0;
                    bool lengthInteger = Int32.TryParse(lengthString, out num);
                    string geoHash = match.Groups["geohash"].Value;

                    string firstCharOfRacer = racer.Substring(0, 1);
                    string lastCharOfRacer = racer.Substring(racer.Length - 1);

                    StringBuilder sb = new StringBuilder();

                    if (firstCharOfRacer == lastCharOfRacer)
                    {
                        if (geoHash.Length == num)
                        {
                            foreach (var character in geoHash)
                            {
                                sb.Append((char)(character + num));
                            }
                            Console.WriteLine($"Coordinates found! {racer.Substring(1, racer.Length - 2)} -> {sb}");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Nothing found!");
                        }
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
