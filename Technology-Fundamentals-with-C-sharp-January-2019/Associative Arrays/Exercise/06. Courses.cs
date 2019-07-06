using System;
using System.Collections.Generic;
using System.Linq;

namespace p06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var coursesWithStudents = new Dictionary<string, List<string>>();

            while (input != "end")
            {
                List<string> tokens = input.Split(" : ").ToList();
                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!coursesWithStudents.ContainsKey(courseName))
                {
                    List<string> students = new List<string>(); //Create new list with students  
                    students.Add(studentName);//Add the student to the list
                    coursesWithStudents.Add(courseName, students);//Add for the current course, current student
                }
                else
                {
                    coursesWithStudents[courseName].Add(studentName);//Add for the current course, current student
                }

                input = Console.ReadLine();
            }

            var ordered = coursesWithStudents.OrderByDescending(x => x.Value.Count);//Order courses by count 4->3->2->1
            
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                var orderedStudents = item.Value.OrderBy(x => x).ToList();//Order student names by letter a->b->c

                foreach (var student in orderedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
