using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string whichWords = Console.ReadLine();

            var database = new Dictionary<string, List<string>>();

            List<string> words = input.Split(" | ").ToList();
            List<string> availableWords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                List<string> definitions = words[i].Split(": ").ToList();
                string currentWord = definitions[0];
                string currentDefinition = definitions[1];

                List<string> defins = new List<string>();

                if (!database.ContainsKey(currentWord))
                {
                    defins.Add(currentDefinition);
                    database.Add(currentWord, defins);
                }
                else if (database.ContainsKey(currentWord))
                {
                    defins.Add(currentDefinition);
                    database[currentWord].Add(currentDefinition);
                }
            }

            List<string> whichWordsToPrint = whichWords.Split(" | ").ToList();

            foreach (var word in whichWordsToPrint)
            {
                if (!availableWords.Contains(word))
                {
                    availableWords.Add(word);
                }
            }

            string command = Console.ReadLine();

            if (command == "End")
            {
                var orderedDict = database.OrderBy(x => x.Key);

                foreach (var kvp in orderedDict)
                {
                    if (availableWords.Contains(kvp.Key))
                    {
                        Console.WriteLine(kvp.Key);
                        Console.WriteLine($" -{string.Join(Environment.NewLine + " -", kvp.Value.OrderByDescending(x => x.Length))}");
                    }               
                }
            }
            else if (command == "List")
            {
                var databaseOrdered = database.OrderBy(x => x.Key);

                foreach (var kvp in databaseOrdered)
                {
                    Console.Write(kvp.Key + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
