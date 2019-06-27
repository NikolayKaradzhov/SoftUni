using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string input = Console.ReadLine();
            string quantity;

            while (input != "stop")
            {
                quantity = Console.ReadLine();

                bool isOnlyLetters = input.All(char.IsLetter);
                bool isOnlyNumbers = quantity.All(char.IsDigit);

                if (isOnlyLetters && isOnlyNumbers)
                {
                    if (!resources.ContainsKey(input))
                    {
                        resources.Add(input, int.Parse(quantity));
                    }
                    else
                    {
                        resources[input] += int.Parse(quantity);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
