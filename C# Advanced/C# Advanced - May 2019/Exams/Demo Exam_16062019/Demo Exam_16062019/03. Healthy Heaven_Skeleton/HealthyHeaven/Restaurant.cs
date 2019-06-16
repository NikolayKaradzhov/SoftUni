using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;

            data = new List<Salad>();
        }

        public int Count => this.data.Count();

        public Salad Calories => this.Calories;

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad saladName = data.FirstOrDefault(n => n.Name == name);

            if (data.Contains(saladName))
            {
                data.Remove(data.FirstOrDefault(s => s.Name == name));
                return true;
            }
            
            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return this.data.OrderBy(x => x.GetTotalCalories()).First();
        }

        public string GenerateMenu()
        {
            return $"{this.Name} have {this.Count} salads:{Environment.NewLine}" +
               $"{string.Join(Environment.NewLine, data)}" ;
        }
    }
}