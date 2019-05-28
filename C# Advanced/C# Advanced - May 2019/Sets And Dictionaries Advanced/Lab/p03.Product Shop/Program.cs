using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!stores.ContainsKey(shop))
                {
                    stores[shop] = new Dictionary<string, double>();
                    stores[shop].Add(product, price);
                }
                else
                {
                    stores[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }
            var ordered = stores.OrderBy(x => x.Key);

            foreach (var kvp in ordered)
            {
                var store = kvp.Key;
                Console.WriteLine($"{store}->");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}