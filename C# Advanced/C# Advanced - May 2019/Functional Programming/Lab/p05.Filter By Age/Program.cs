using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                
            var namesWithAge = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                namesWithAge.Add(new KeyValuePair<string, int>(name, age));
            }

            string filter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] printPattern = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            namesWithAge.Where(p => filter == "younger" ? p.Value < ageFilter : p.Value >= ageFilter)
                .ToList()
                .ForEach(p => Printer(p , printPattern));
        }

        static void Printer(KeyValuePair<string, int> person, string[] printPattern)
        {
            if (printPattern.Length == 2)
            {
                Console.WriteLine(printPattern[0] == "name" ? 
                    $"{person.Key} - {person.Value}" :
                    $"{person.Value} - {person.Key}");
            }
            else
            {
                Console.WriteLine(printPattern[0] == "name" ?
                    $"{person.Key}" :
                    $"{person.Value}");
            }
        }
    }
}