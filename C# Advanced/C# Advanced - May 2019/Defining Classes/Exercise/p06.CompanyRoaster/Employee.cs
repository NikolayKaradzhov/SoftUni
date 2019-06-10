using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace p06.CompanyRoaster
{
    class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.age = age;
        }

        [Required]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [Required]
        public double Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        [Required]
        public string Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        [Required]
        public string Department
        {
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}