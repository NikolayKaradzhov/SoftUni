using System;
using System.Collections.Generic;
using System.Linq;

namespace p07.Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> database = new Dictionary<string, List<double>>();
            int pairOfRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairOfRows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

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

            Dictionary<string, double> readyList = new Dictionary<string, double>();

            foreach (var item in database)
            {
                var average = item.Value.Average();
                if (average >= 4.50)
                {
                    readyList.Add(item.Key, average);
                }
            }
            var ordered = readyList.OrderByDescending(x => x.Value);

            foreach (var grade in ordered)
            {
                Console.WriteLine($"{grade.Key} -> {grade.Value:f2}");
            }
        }
    }
}
