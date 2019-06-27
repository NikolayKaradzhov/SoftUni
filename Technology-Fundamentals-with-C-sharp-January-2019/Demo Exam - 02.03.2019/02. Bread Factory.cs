using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> events = Console.ReadLine().Split("|").ToList();

            int initialEnergy = 100;
            int coins = 100;
            string command = string.Empty;
            int currentEnergy = initialEnergy;
            string ingredient = string.Empty;
            int ingredientPrice = 0;
            bool isDayCompleted = false;

            for (int i = 0; i < events.Count; i++)
            {
                command = events[i];

                string[] tokens = command.Split("-");

                if (tokens[0] == "rest")
                {
                    int energyToGain = int.Parse(tokens[1]);

                    if (currentEnergy + energyToGain > initialEnergy)
                    {
                        int energy = initialEnergy - currentEnergy;
                        Console.WriteLine($"You gained {energy} energy.");
                        currentEnergy += energy;
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                    }
                    else
                    {
                        currentEnergy += energyToGain;
                        Console.WriteLine($"You gained {energyToGain} energy.");
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                       
                    }
                }
                else if (tokens[0] == "order")
                {
                    currentEnergy -= 30;

                    if (currentEnergy >= 0)
                    {
                        int coinsEarned = int.Parse(tokens[1]);
                        Console.WriteLine($"You earned {coinsEarned} coins.");
                        coins += coinsEarned;
                        
                    }
                    else if (currentEnergy < 0)
                    {
                        Console.WriteLine($"You had to rest!");
                        currentEnergy += 80;
                        
                    }
                }
                else
                {
                    ingredient = tokens[0];
                    ingredientPrice = int.Parse(tokens[1]);

                    if (coins > ingredientPrice)
                    {
                        Console.WriteLine($"You bought {ingredient}.");
                        coins -= ingredientPrice;
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        return;
                    }
                }
            }
            Console.WriteLine($"Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {currentEnergy}");
        }
    }
}
