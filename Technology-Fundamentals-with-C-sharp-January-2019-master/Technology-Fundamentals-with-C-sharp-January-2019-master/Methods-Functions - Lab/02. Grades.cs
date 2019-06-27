using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGradeWithWords(double.Parse(Console.ReadLine()));
        }
        private static void PrintGradeWithWords(double readGrade)
        {
            if (readGrade >= 2.00 && readGrade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (readGrade >= 3.00 && readGrade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (readGrade >= 3.50 && readGrade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (readGrade >= 4.50 && readGrade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (readGrade >= 5.50 && readGrade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
