using System;
using System.Collections.Generic;
using System.Text;

namespace p11.PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string Element, int health)
        {
            this.Name = name;
            this.Element = Element;
            this.Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}