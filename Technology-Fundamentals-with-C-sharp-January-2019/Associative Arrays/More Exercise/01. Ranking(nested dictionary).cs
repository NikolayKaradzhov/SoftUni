using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var database = new Dictionary<string, Dictionary<string, int>>(); //nested dictionary
            string name = string.Empty;

            string readContest = Console.ReadLine();

            while (readContest != "end of contests")
            {
                List<string> tokens = readContest.Split(":").ToList();

                string contest = tokens[0];
                string password = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                readContest = Console.ReadLine();
            }

            string submissions = string.Empty;

            while ((submissions = Console.ReadLine()) != "end of submissions")
            {
                List<string> results = submissions.Split("=>").ToList();

                string course = results[0];
                string passwordForCourse = results[1];
                name = results[2];
                int points = int.Parse(results[3]);

                if (contests.ContainsKey(course) && contests[course] == passwordForCourse)
                {
                    if (!database.ContainsKey(name))
                    {
                        //allocate memory for "inner" dictionary
                        Dictionary<string, int> dict = new Dictionary<string, int>();
                        dict.Add(course, points); //add course and points in the inner dictionary
                        database.Add(name, dict); //add for the current key, the inner dictionary info
                    }
                    else if (database.ContainsKey(name) && !database[name].ContainsKey(course))
                    {
                        Dictionary<string, int> dict = new Dictionary<string, int>();

                        database[name].Add(course, points);
                    }
                    else if (database.ContainsKey(name) && database[name].ContainsKey(course))
                    {
                        //compare poins
                        if (database[name][course] < points)
                        {
                            database[name][course] = points;
                        }
                    }

                }
                else
                {
                    continue;
                }
            }
            var bestCandidate = database[name];
            string bestPerson = string.Empty;
            int currentBestPoints = 0;
            int bestPoints = 0;

            //itterate through database.Keys to get the name of the winner with best points
            foreach (var item in database)
            {
                //itterate through all the points in the inner dictionary to get the bestPoints
                foreach (var kvp in item.Value)
                {
                    currentBestPoints += kvp.Value;
                }
                if (currentBestPoints > bestPoints)
                {
                    bestPoints = currentBestPoints;
                    bestPerson = item.Key;
                }
                currentBestPoints = 0;
            }

            Console.WriteLine($"Best candidate is {bestPerson} " +
                $"with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            var ordered = database.OrderBy(x => x.Key);

            foreach (var item in ordered)
            {
                Console.WriteLine(item.Key);

                foreach (var course in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
