using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }
        public string Name { get; private set; }

        public int Count => this.products.Count();

        public int GetTotalCalories()
        {
            /*int maxCalories = 0;

            foreach (var salad in products)
            {
                maxCalories += salad.Calories;
            }

            return maxCalories;
			*/
			return this.products.Sum(p => p.Calories);
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public int GetProductCount()
        {
            return this.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (var item in this.products)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}