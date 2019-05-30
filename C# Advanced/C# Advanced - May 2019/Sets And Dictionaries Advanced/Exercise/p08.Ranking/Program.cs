using System;
using System.Collections.Generic;
using System.Linq;

namespace p08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contest = new Dictionary<string, string>();
            var results = new Dictionary<string, Dictionary<string, int>>();

            string inputContests = Console.ReadLine();

            while (inputContests != "end of contests")
            {
                string[] tokens = inputContests
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string contestName = tokens[0];
                string contestPassword = tokens[1];

                if (!contest.ContainsKey(contestName))
                {
                    contest.Add(contestName, contestPassword);
                }

                inputContests = Console.ReadLine();
            }

            string submissions = Console.ReadLine();

            while (submissions != "end of submissions")
            {
                string[] tokens = submissions
                .Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);

                string course = tokens[0];
                string pass = tokens[1];
                string contesterName = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contest.ContainsKey(course) && contest[course] == pass)
                {
                    if (!results.ContainsKey(contesterName))
                    {
                        results.Add(contesterName, new Dictionary<string, int>());
                    }

                    if (!results[contesterName].ContainsKey(course))
                    {
                        results[contesterName].Add(course, points);
                    }
                    else if (points > results[contesterName][course])
                    {
                        results[contesterName][course] = points;
                    }
                }

                submissions = Console.ReadLine();
            }

            int totalPoints = int.MinValue;
            string bestCandidate = string.Empty;

            foreach (var kvp in results)
            {
                string currentCandidate = kvp.Key;
                int currentPoints = 0;

                foreach (var item in kvp.Value)
                {
                    int currentCoursePoints = item.Value;
                    currentPoints += currentCoursePoints;
                }

                if (currentPoints > totalPoints)
                {
                    totalPoints = currentPoints;
                    bestCandidate = currentCandidate;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            var ordered = results.OrderBy(x => x.Key);

            foreach (var kvp in ordered)
            {
                string name = kvp.Key;
                Console.WriteLine(name);

                var orderByPoints = kvp.Value.OrderByDescending(x => x.Value);

                foreach (var item in orderByPoints)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}