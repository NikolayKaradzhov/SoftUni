using System;
using System.Collections.Generic;
using System.Linq;

namespace p04.List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesRead = int.Parse(Console.ReadLine());
            List<string> readProducts = new List<string>();

            for (int i = 0; i < linesRead; i++)
            {
                string products = Console.ReadLine();
                readProducts.Add(products);
            }
            readProducts.Sort();
            for (int i = 0; i < readProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{readProducts[i]}");
            }
        }
    }
}
