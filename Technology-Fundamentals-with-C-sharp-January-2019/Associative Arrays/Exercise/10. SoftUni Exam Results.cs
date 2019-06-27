using System;
using System.Collections.Generic;
using System.Linq;

namespace p10.SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                List<string> tokens = input.Split("-").ToList();
                string userName = tokens[0];
                string language = tokens[1];
                
                if (language == "banned")
                {
                    results.Remove(userName);
                }
                else
                {
                    int points = int.Parse(tokens[2]);

                    if (!results.ContainsKey(userName) && !submissions.ContainsKey(language))
                    {
                        results.Add(userName, points);
                        submissions.Add(language, 1);
                    }
                    else if (!results.ContainsKey(userName) && submissions.ContainsKey(language))
                    {
                        results.Add(userName, points);
                        submissions[language]++;
                    }
                    else if (results.ContainsKey(userName) && !submissions.ContainsKey(language))
                    {
                        submissions[language]++;
                    }
                    else if (results.ContainsKey(userName)
                        && submissions.ContainsKey(language)
                        && results[userName] < points)
                    {
                        results[userName] = points;
                        submissions[language]++;
                    }
                    else if (results.ContainsKey(userName)
                        && submissions.ContainsKey(language)
                        && results[userName] > points)
                    {
                        submissions[language]++;
                    }
                }
                input = Console.ReadLine();
            }
            var resultsOrderedByDescending = results
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach (var item in resultsOrderedByDescending)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            var submissionsOrdered = submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            Console.WriteLine("Submissions:");

            foreach (var item in submissionsOrdered)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
