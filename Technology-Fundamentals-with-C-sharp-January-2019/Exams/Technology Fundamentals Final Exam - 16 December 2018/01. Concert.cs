using System;
using System.Collections.Generic;
using System.Linq;

namespace p01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> bandNameTime = new Dictionary<string, int>();
            Dictionary<string, List<string>> bandNameSingerName = new Dictionary<string, List<string>>();

            List<string> currentInput = new List<string>();

            string band = string.Empty;

            while (input != "start of concert")
            {
                if (input.Contains("Add"))
                {
                    currentInput = input.Split(";").ToList();
                    band = currentInput[1];

                    string[] members = currentInput[2].Split(", ", StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < members.Length; i++)
                    {
                        List<string> names = new List<string>();

                        string currentName = members[i].TrimStart();
                        names.Add(currentName);

                        if (!bandNameSingerName.ContainsKey(band))
                        {
                            bandNameSingerName.Add(band, names);
                        }
                        else if (!bandNameSingerName[band].Contains(currentName))
                        {
                            bandNameSingerName[band].Add(currentName);
                        }
                    }

                }
                else if (input.Contains("Play"))
                {
                    currentInput = input.Split(";").ToList();
                    band = currentInput[1];
                    int playTime = int.Parse(currentInput[2]);

                    if (!bandNameTime.ContainsKey(band))
                    {
                        bandNameTime.Add(band, 0);
                    }
                    bandNameTime[band] += playTime;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            int totalTimePlayed = bandNameTime.Values.Sum();
            Console.WriteLine($"Total time: {totalTimePlayed}");

            var ordered = bandNameTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var kvp in ordered)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine(input);

            foreach (var kvp in bandNameSingerName)
            {
                if (kvp.Key.Contains(input))
                {
                    foreach (var item in kvp.Value)
                    {
                        Console.WriteLine($"=> {item}");
                    }
                }
            }
        }
    }
}
