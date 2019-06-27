using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> database = new Dictionary<string, double[]>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                List<string> tokens = input.Split().ToList();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!database.ContainsKey(product))
                {
                    database.Add(product, new double[2]);
                }
                database[product][0] = price;
                database[product][1] += quantity;

                input = Console.ReadLine();
            }

            foreach (var item in database)
            {
                var result = item.Value[0] * item.Value[1];

                Console.WriteLine($"{item.Key} -> {result:f2}");
            }
        }
    }
}
