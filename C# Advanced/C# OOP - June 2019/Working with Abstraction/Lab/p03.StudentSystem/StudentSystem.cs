namespace p03.StudentSystem
{
    using System;
    using System.Collections.Generic;
    public class StudentSystem
    {
        public StudentSystem()
        {
            Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; private set; }

        public void Add(string name, int age, double grade)
        {
            if (!Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Students[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (!Students.ContainsKey(name))
            {
                throw new ArgumentException($"Student with name {name} could not be found!");
            }

            var student = Students[name];

            return student;
        }
    }
}