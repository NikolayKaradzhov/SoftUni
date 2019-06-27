using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal totalInsertedCoins = 0.0m;

            string userInput = string.Empty;
            string products = string.Empty;
            decimal coins = 0.0m;

            while ((userInput = Console.ReadLine()) != "Start")
            {
                coins = decimal.Parse(userInput);

                if (coins == 0.1m)
                {
                    totalInsertedCoins += coins;
                }
                else if (coins == 0.2m)
                {
                    totalInsertedCoins += coins;
                }
                else if (coins == 0.5m)
                {
                    totalInsertedCoins += coins;
                }
                else if (coins == 1.0m)
                {
                    totalInsertedCoins += coins;
                }
                else if (coins == 2.0m)
                {
                    totalInsertedCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
            }

            while ((userInput = Console.ReadLine()) != "End")
            {
                products = userInput;

                if (products.Equals("Nuts"))
                {
                    if (totalInsertedCoins < 2.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalInsertedCoins -= 2.0m;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else if (products.Equals("Water"))
                {
                    if (totalInsertedCoins < 0.7m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalInsertedCoins -= 0.7m;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else if (products.Equals("Crisps"))
                {
                    if (totalInsertedCoins < 1.5m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalInsertedCoins -= 1.5m;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else if (products.Equals("Soda"))
                {
                    if (totalInsertedCoins < 0.8m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalInsertedCoins -= 0.8m;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else if (products.Equals("Coke"))
                {
                    if (totalInsertedCoins < 1.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalInsertedCoins -= 1.0m;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {totalInsertedCoins:F2}");
        }
    }
}
