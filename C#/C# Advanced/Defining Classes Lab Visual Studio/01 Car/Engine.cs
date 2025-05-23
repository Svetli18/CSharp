﻿namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine()
        {
        }

        public Engine(int horsePower, double cubicCapacity)
            : this()
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }

        public double CubicCapacity { get => this.cubicCapacity; set => this.cubicCapacity = value; }

    }
}
