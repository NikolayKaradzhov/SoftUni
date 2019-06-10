using System;
using System.Collections.Generic;
using System.Linq;

namespace p11.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainersList = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] tokens = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainersList.Exists(x => x.Name == trainerName))
                {
                    int currentTrainerIndex = trainersList.FindIndex(x => x.Name == trainerName);
                    trainersList[currentTrainerIndex].CollectionOfPokemon.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, pokemon);
                    trainersList.Add(trainer);
                }

                input = Console.ReadLine();
            }

            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                foreach (var trainer in trainersList)
                {
                    if (trainer.CollectionOfPokemon.Exists(x => x.Element == inputLine))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.CollectionOfPokemon.ForEach(x => x.Health -= 10);
                        trainer.CollectionOfPokemon.RemoveAll(x => x.Health <= 0);
                    }
                }

                inputLine = Console.ReadLine();
            }

            foreach (var trainer in trainersList.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemon.Count}");
            }
        }
    }
}