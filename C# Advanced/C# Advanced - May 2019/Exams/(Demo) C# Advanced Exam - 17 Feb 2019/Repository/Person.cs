using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
    }
}