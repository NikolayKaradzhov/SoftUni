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
            double currentBalance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            double outFall4Price = 39.99;
            double csOGPrice = 15.99;
            double zplinterZellPrice = 19.99;
            double honore2Price = 59.99;
            double roverWatchPrice = 29.99;
            double roverWatchOriginsEditionPrice = 39.99;

            double totalSpent = 0.0;

            while (input != "Game Time")
            { 
                if (currentBalance > 0)
                {
                    switch (input)
                    {
                        case "OutFall 4":
                            if (currentBalance < outFall4Price)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= outFall4Price;
                                totalSpent += outFall4Price;
                            }
                            break;
                        case "CS: OG":
                            if (currentBalance < csOGPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= csOGPrice;
                                totalSpent += csOGPrice;
                            }
                            break;
                        case "Zplinter Zell":
                            if (currentBalance < zplinterZellPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= zplinterZellPrice;
                                totalSpent += zplinterZellPrice;
                            }
                            break;
                        case "Honored 2":
                            if (currentBalance < honore2Price)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= honore2Price;
                                totalSpent += honore2Price;
                            }
                            break;
                        case "RoverWatch":
                            if (currentBalance < roverWatchPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= roverWatchPrice;
                                totalSpent += roverWatchPrice;
                            }
                            break;
                        case "RoverWatch Origins Edition":
                            if (currentBalance < roverWatchOriginsEditionPrice)
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            else
                            {
                                Console.WriteLine($"Bought {input}");
                                currentBalance -= roverWatchOriginsEditionPrice;
                                totalSpent += roverWatchOriginsEditionPrice;
                            }
                            break;

                        default:
                            Console.WriteLine("Not Found");
                            break;
                    }
                }
                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${currentBalance:F2}");
        }
    }
}
