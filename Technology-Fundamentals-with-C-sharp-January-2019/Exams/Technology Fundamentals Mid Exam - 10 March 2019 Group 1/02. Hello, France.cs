using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Hello_France
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal budget = decimal.Parse(Console.ReadLine());

            decimal clothesMAXPrice = 50.00m;
            decimal shoesMAXPrice = 35.00m;
            decimal accessoriesMAXPrice = 20.50m;
            string command = string.Empty;
            int start = 0;
            decimal increasedPrice = 0.00m;

            decimal profit = 0.00m;
            decimal currentProfit = 0.00m;
            decimal newBudget = 0.00m;

            List<string> tokens = input.Split("|").ToList();

            List<decimal> newPrices = new List<decimal>();

            for (int i = start; i < tokens.Count; i++)
            {
                command = tokens[i];
                List<string> readyList = command.Split("->").ToList();

                string item = readyList[0];
                decimal itemPrice = decimal.Parse(readyList[1]);

                if (item == "Clothes")
                {
                    if (budget < itemPrice)
                    {
                        continue;
                    }
                    else if (itemPrice > clothesMAXPrice)
                    {
                        
                    }
                    else
                    {
                        budget = budget - itemPrice;
                        increasedPrice = (itemPrice * 0.4m) + itemPrice;
                        currentProfit = increasedPrice - itemPrice;
                        profit += currentProfit;
                        increasedPrice = Math.Round(increasedPrice, 2);
                        newPrices.Add(increasedPrice);
                    }
                }

                if (item == "Shoes")
                {
                    if (budget < itemPrice)
                    {
                        continue;
                    }
                    else if (itemPrice > shoesMAXPrice)
                    {
                       
                    }
                    else
                    {
                        budget = budget - itemPrice;
                        increasedPrice = (itemPrice * 0.4m) + itemPrice;
                        currentProfit = increasedPrice - itemPrice;
                        profit += currentProfit;
                        increasedPrice = Math.Round(increasedPrice, 2);
                        newPrices.Add(increasedPrice);
                    }
                }
                if (item == "Accessories")
                {
                    if (budget < itemPrice)
                    {
                        continue;
                    }
                    else if (itemPrice > accessoriesMAXPrice)
                    {
                        
                    }
                    else
                    {
                        budget = budget - itemPrice;
                        increasedPrice = (itemPrice * 0.4m) + itemPrice;
                        currentProfit = increasedPrice - itemPrice;
                        profit += currentProfit;
                        increasedPrice = Math.Round(increasedPrice, 2);
                        newPrices.Add(increasedPrice);
                    }
                }
            }
            newBudget = budget + newPrices.Sum();
            newBudget = Math.Round(newBudget, 2);

            if (newBudget >= 150)
            {
                foreach (var number in newPrices)
                {
                    Console.Write($"{number:f2} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Hello, France!");
            }
            else
            {
                foreach (var number in newPrices)
                {
                    Console.Write($"{number:f2} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Time to go.");
            }
        }
    }
}
