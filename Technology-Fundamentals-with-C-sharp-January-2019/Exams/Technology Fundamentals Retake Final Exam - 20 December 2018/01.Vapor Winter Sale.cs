using System;
using System.Collections.Generic;
using System.Linq;

namespace 01.Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            var games = new Dictionary<string, double>();
            var gamesWithDLC = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ");

            double price = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                string gameWithPrice = input[i];

                if (gameWithPrice.Contains("-"))
                {
                    List<string> tokens = gameWithPrice.Split("-").ToList();
                    string game = tokens[0];
                    price = double.Parse(tokens[1]);

                    if (!games.ContainsKey(game))
                    {
                        games.Add(game, 0);
                    }

                    games[game] = price;
                }
                else if (gameWithPrice.Contains(":"))
                {
                    List<string> tokens2 = gameWithPrice.Split(":").ToList();
                    string currentGame = tokens2[0];
                    string DLC = tokens2[1];

                    if (games.ContainsKey(currentGame))
                    {
                        gamesWithDLC.Add(currentGame, new Dictionary<string, double>());
                        price = games[currentGame] * 1.2;
                        gamesWithDLC[currentGame].Add(DLC, price);
                        games.Remove(currentGame);
                    }
                }
            }

            var gameDLC = gamesWithDLC
                .SelectMany(kv => kv.Value.Select(kvInner => new { Name = kv.Key, DLC = kvInner.Key, Price = kvInner.Value }))
                .OrderBy(x => x.Price);

            foreach (var kvp in gameDLC)
            {
                Console.WriteLine($"{kvp.Name} - {kvp.DLC} - {kvp.Price * 0.5:F2}");
            }

            foreach (var kvp in games.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value * 0.8:F2}");
            }
        }
    }
}
