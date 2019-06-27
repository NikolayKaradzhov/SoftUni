using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> database = new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();

                List<string> tokens = input.Split(" ").ToList();

                string userName = tokens[1];

                if (tokens[0] == "register")
                {
                    string licensePlateNumber = tokens[2];

                    if (database.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        database.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                }
                else if (tokens[0] == "unregister")
                {
                    if (database.ContainsKey(userName))
                    {
                        Console.WriteLine($"{userName} unregistered successfully");
                        database.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }
            foreach (var item in database)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
