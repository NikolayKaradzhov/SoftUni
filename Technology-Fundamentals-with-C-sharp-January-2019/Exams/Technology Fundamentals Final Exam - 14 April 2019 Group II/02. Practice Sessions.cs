using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> database = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                string[] tokens = input.Split("->");

                string command = tokens[0];

                if (command == "Add")
                {
                    string road = tokens[1];
                    string racer = tokens[2];

                    if (!database.ContainsKey(road))
                    {
                        database.Add(road, new List<string>());
                        database[road].Add(racer);
                    }
                    else if (database.ContainsKey(road))
                    {
                        database[road].Add(racer);
                    }
                }
                else if (command == "Move")
                {
                    string currentRoad = tokens[1];
                    string racer = tokens[2];
                    string nextRoad = tokens[3];

                    if (database[currentRoad].Contains(racer))
                    {
                        database[currentRoad].Remove(racer);
                        database[nextRoad].Add(racer);
                    }
                }
                else if (command == "Close")
                {
                    string road = tokens[1];

                    if (database.ContainsKey(road))
                    {
                        database.Remove(road);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Practice sessions:");

            var ordered = database.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var kvp in ordered)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"++{item}");
                }
            }
        }
    }
}
