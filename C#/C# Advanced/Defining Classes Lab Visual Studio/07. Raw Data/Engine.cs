using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine()
        {
        }

        public Engine(int speed, int power)
            :this()
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Speed { get => this.speed; set => this.speed = value; }

        public int Power { get => this.power; set => this.power = value; }

    }
}
