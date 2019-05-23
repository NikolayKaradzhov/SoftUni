using System;
using System.Collections.Generic;

namespace p04.Cities_by_Continent_and_Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Dictionary<string, List<string>>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!database.ContainsKey(continent))
                {
                    database[continent] = new Dictionary<string, List<string>>();
                }
                if(!database[continent].ContainsKey(country))
                {
                    database[continent][country] = new List<string>();
                }
                database[continent][country].Add(city);
            }
            foreach (var kvp in database)
            {
                var continent = kvp.Key;

                Console.WriteLine($"{continent}:");

                foreach (var item in kvp.Value)
                {
                    var country = item.Key;
                    List<string> cities = item.Value;

                    Console.Write($"{country} -> {string.Join(", ", cities)}");

                  
                    Console.WriteLine();
                }
            }
        }
    }
}
