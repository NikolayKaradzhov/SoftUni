using System;
using System.Collections.Generic;
using System.Linq;

namespace p10.Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] items = command
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string condition = items[2];

                Func<string, bool> filter;

                switch (items[0])
                {
                    case "Remove" when items[1] == "StartsWith":
                        filter = x => !x.StartsWith(condition);
                        break;

                    case "Remove" when items[1] == "EndsWith":
                        filter = x => !x.EndsWith(condition);
                        break;

                    case "Remove":
                        filter = x => x.Length != int.Parse(condition);
                        break;

                    case "Double" when items[1] == "StartsWith":
                        filter = x => x.StartsWith(condition);
                        break;

                    case "Double" when items[1] == "EndsWith":
                        filter = x => x.EndsWith(condition);
                        break;

                    default:
                        filter = x => x.Length == int.Parse(condition);
                        break;
                }

                if (items[0] == "Remove")
                {
                    guests = guests.Where(filter).ToList();
                }
                else
                {
                    List<string> list = guests.Where(filter).ToList();

                    foreach (var name in list)
                    {
                        var index = guests.IndexOf(name);
                        guests.Insert(index, name);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Any()
                ? $"{string.Join(", ", guests)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}