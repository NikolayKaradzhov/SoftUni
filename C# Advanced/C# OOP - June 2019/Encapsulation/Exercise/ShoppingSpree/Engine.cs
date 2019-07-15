namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Person> people;
        private readonly List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                string[] inputPeople = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string[] inputProducts = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                this.AddPerson(inputPeople);
                this.AddProduct(inputProducts);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] inputInfo = command
                        ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = inputInfo[0];
                    string productName = inputInfo[1];

                    Person targetPerson = this.people.FirstOrDefault(p => p.Name == personName);
                    Product targetProduct = this.products.FirstOrDefault(p => p.Name == productName);

                    if (targetProduct != null && targetPerson != null)
                    {
                        Console.WriteLine(targetPerson.AddProductToBag(targetProduct));
                    }

                    command = Console.ReadLine();
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddProduct(string[] productsInformation)
        {
            foreach (string productData in productsInformation)
            {
                string[] data = productData
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string productName = data[0];
                decimal productPrice = decimal.Parse(data[1]);

                Product product = new Product(productName, productPrice);
                this.products.Add(product);
            }
        }

        private void AddPerson(string[] personInformation)
        {
            foreach (string personData in personInformation)
            {
                string[] data = personData
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string personName = data[0];
                decimal personMoney = decimal.Parse(data[1]);

                Person person = new Person(personName, personMoney);
                this.people.Add(person);
            }
        }
    }
}