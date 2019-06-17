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

        public string Name { get; private set; }

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
			else
			{
				return false;	
            }
            
        }

        public Salad GetHealthiestSalad()
        {
            //return this.data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
			
			int min = this.data.Min(s => s.GetTotalCalories());

            return this.data.FirstOrDefault(s => s.GetTotalCalories() == min);
        }

        public string GenerateMenu()
        {
            //return $"{this.Name} have {this.Count} salads:{Environment.NewLine}" +
               //$"{string.Join(Environment.NewLine, data)}" ;
			   
			   StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}