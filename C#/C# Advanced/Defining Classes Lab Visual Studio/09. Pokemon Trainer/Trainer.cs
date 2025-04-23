using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09._Pokemon_Trainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer()
        {
            this.pokemons = new List<Pokemon>();
        }

        public Trainer(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name { get => this.name; set => this.name = value; }

        public int NumberOfBadges { get => this.numberOfBadges; }

        public List<Pokemon> Pokemons { get => this.pokemons; set => this.pokemons = value; }

        public void AddBadge()
        {
            this.numberOfBadges++;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void RemovePokemon(Pokemon pokemon)
        {
            pokemons.Remove(pokemon);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
