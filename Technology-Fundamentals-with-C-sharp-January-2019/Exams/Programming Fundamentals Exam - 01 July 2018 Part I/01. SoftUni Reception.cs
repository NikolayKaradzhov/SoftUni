using System;

namespace p01.SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int allEmployeesAnswerHours = firstEmployeeEfficiency 
                + secondEmployeeEfficiency 
                + thirdEmployeeEfficiency;

            int hours = 0;

            while (studentsCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }

                studentsCount -= allEmployeesAnswerHours;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
