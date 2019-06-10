using System;
using System.Collections.Generic;
using System.Text;

namespace p11.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon collectionOfPokemon)
        {
            this.Name = name;
            this.CollectionOfPokemon.Add(collectionOfPokemon);
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemon { get; set; } = new List<Pokemon>();   
    }
}