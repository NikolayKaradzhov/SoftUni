using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p02.SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$";

            double totalIncome = 0.0;
            while (input != "end of shift")
            {
                Regex order = new Regex(pattern);

                if (order.IsMatch(input))
                {
                    string customerName = order.Match(input).Groups["name"].Value;
                    string product = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = price * count;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
