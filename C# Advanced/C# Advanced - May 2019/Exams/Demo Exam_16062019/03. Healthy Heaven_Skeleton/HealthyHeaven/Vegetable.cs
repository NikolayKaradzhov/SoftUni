using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
            sb.AppendLine($" - {this.Name} have {this.Calories} calories");
            return sb.ToString().TrimEnd();
        }
    }
}