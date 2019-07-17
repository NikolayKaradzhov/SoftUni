namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : Border
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get => this.age;

            private set => this.age = value;
        }

        public string Name
        {
            get => this.name;

            private set => this.name = value;
        }
    }
}
