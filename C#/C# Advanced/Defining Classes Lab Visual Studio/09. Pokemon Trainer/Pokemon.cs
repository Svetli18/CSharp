using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Pokemon_Trainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon()
        {           
        }

        public Pokemon(string name, string element, int health)
            :this()
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get => this.name; set => this.name = value; }

        public string Element { get => this.element; set => this.element = value; }

        public int Health { get => this.health; set => this.health = value; }

    }
}
