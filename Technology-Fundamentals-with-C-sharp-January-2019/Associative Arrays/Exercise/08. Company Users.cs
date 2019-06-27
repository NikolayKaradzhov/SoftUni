using System;
using System.Collections.Generic;
using System.Linq;

namespace p08.Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                List<string> tokens = input.Split(" -> ").ToList();
                string company = tokens[0];
                string employeeID = tokens[1];

                if (!database.ContainsKey(company))
                {
                    List<string> employees = new List<string>();
                    employees.Add(employeeID);
                    database.Add(company, employees);
                }
                else if (database.ContainsKey(company) && !database[company].Contains(employeeID))
                {
                    database[company].Add(employeeID);
                }
                else if (database.ContainsKey(company) && database[company].Contains(employeeID))
                {

                }
                    input = Console.ReadLine();
            }

            var ordered = database.OrderBy(x => x.Key);

            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
