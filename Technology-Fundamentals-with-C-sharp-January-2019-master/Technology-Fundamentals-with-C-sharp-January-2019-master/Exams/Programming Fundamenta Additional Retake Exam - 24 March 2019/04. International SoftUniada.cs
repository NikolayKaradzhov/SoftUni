using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04.International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputSplitted = input.Split(" -> ");

                string country = inputSplitted[0];
                string name = inputSplitted[1];
                int points = int.Parse(inputSplitted[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, int>());
                    dict[country].Add(name, points);
                }
                else if (!dict[country].ContainsKey(name))
                {
                    dict[country].Add(name, points);
                }
                else if (dict[country].ContainsKey(name))
                {
                    dict[country][name] += points;
                }
                input = Console.ReadLine();
            }

            Dictionary<string, int> finalPointsCountries = new Dictionary<string, int>();

            foreach (var item in dict)
            {
                int totalPoints = item.Value.Values.Sum();

                finalPointsCountries.Add(item.Key, totalPoints);
            }

            var ordered = finalPointsCountries.OrderByDescending(x => x.Value);

            string countryy = string.Empty;

            foreach (var kvp in ordered)
            {
                countryy = kvp.Key;
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

                foreach (var item in dict)
                {
                    string currentCountry = item.Key;

                    if (countryy == currentCountry)
                    {
                        foreach (var hooman in item.Value)
                        {
                            Console.WriteLine($" -- {hooman.Key} -> {hooman.Value}");
                        }
                    }
                }
            }
        }
    }
}
