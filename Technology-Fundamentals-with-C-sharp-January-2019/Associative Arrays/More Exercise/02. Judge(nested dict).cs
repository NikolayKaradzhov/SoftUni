using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Dictionary<string, int>>();
            var totalPoints = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                List<string> tokens = input.Split(" -> ").ToList();

                string userName = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                //check if such contest already exists and if not, add it
                if (!database.ContainsKey(contest))
                {
                    var userPoints = new Dictionary<string, int>();
                    userPoints.Add(userName, points);
                    database.Add(contest, userPoints);

                    if (!totalPoints.ContainsKey(userName))
                    {
                        totalPoints.Add(userName, points);
                        totalPoints[userName] = points;
                    }
                    else 
                    {
                        totalPoints[userName] += points;
                    }
                }
                else if (database.ContainsKey(contest))
                {
                    if (database[contest].ContainsKey(userName) && database[contest][userName] < points)
                    {
                        database[contest][userName] = points;
                        totalPoints[userName] = points;
                    }
                    else if (!database[contest].ContainsKey(userName))
                    {
                        database[contest].Add(userName, points);

                        if (!totalPoints.ContainsKey(userName))
                        {
                            totalPoints.Add(userName, points);
                            totalPoints[userName] = points;
                        }
                        else
                        {
                            totalPoints[userName] += points;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            foreach (var item in database)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                int i = 1;
                var order = item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

                foreach (var kvp in order)
                {
                    Console.WriteLine($"{i}. {kvp.Key} <::> {kvp.Value}");
                    i++;
                }     
            }
            Console.WriteLine("Individual standings:");

            var ordered = totalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            int j = 1;
            foreach (var item in ordered)
            {
                Console.WriteLine($"{j}. {item.Key} -> {item.Value}");
                j++;
            }
        }
    }
}
