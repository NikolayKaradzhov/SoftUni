using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<double>>();

            int kidsCount = int.Parse(Console.ReadLine());

            

            for (int i = 0; i < kidsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!database.ContainsKey(name))
                {
                    List<double> grades = new List<double>();
                    grades.Add(grade);
                    database.Add(name, grades);
                }
                else
                {
                    database[name].Add(grade);
                }
            }
            foreach (var kvp in database)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var item in kvp.Value)
                {
                    Console.Write($"{item:F2} ");
                }

                var averageScore = kvp.Value.Average();

                Console.WriteLine($"(avg: {averageScore:F2})");
            }
        }
    }
}