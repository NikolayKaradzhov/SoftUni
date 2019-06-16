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
            products = new List<Vegetable>();
        }
        public string Name { get; set; }

        public int Calories { get; set; }

        public int Count => this.products.Count();

        public int GetTotalCalories()
        {
            int maxCalories = 0;

            foreach (var salad in products)
            {
                maxCalories += salad.Calories;
            }

            return maxCalories;
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
            return $"* Salad {this.Name} is { GetTotalCalories() } calories and have {this.Count} products:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, products)}";
        }
    }
}