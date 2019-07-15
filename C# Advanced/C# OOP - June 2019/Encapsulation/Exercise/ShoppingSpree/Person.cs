namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string AddProductToBag(Product product)
        {
            if (product.Cost > this.Money)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.bagOfProducts.Count == 0)
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }
            else
            {
                List<string> productsNames = new List<string>();

                this.bagOfProducts.ForEach(p => productsNames.Add(p.Name));

                sb.Append($"{this.Name} - {string.Join(", ", productsNames)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}