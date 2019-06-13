using System;
using System.Collections.Generic;
using System.Linq;

namespace p06.CompanyRoaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            List<Employee> employeesList = new List<Employee>();

            for (int i = 0; i < rowsCount; i++)
            {
                string[] employeeData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string position = employeeData[2];
                string department = employeeData[3];
                string email = string.Empty;
                int age = 0;

                //check if employee has email
                if (employeeData.Length == 4)
                {
                    email = "n/a";
                }
                else
                {
                    if (employeeData.Length == 5 && employeeData[4].Contains("@"))
                    {
                        email = employeeData[4];
                    }
                }

                //check for non mandatory field "age"

                if (employeeData.Length > 5 && email != "n/a" && employeeData[5] != null)
                {
                    age = int.Parse(employeeData[5]);
                }
                else if (employeeData.Length > 4 && email == "n/a" && employeeData[4] != null)
                {
                    age = int.Parse(employeeData[4]);
                }
                else
                {
                    age = -1;
                }

                Employee employee = new Employee(name, salary, position, department, email, age);
                employeesList.Add(employee);


            }
            var highestAverageByDepartment = employeesList.GroupBy(x => x.Department)
                .OrderByDescending(x => x.Select(y => y.Salary).Average())
                .FirstOrDefault()
                .Key;

            Console.WriteLine($"Highest Average Salary: {highestAverageByDepartment}");

            foreach (var employee in employeesList.Where(x => x.Department == highestAverageByDepartment).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}