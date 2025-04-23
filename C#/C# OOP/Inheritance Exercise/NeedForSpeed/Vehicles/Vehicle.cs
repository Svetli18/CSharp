namespace NeedForSpeed.Vehicles
{
    using System;

    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private int horsePower;

        private double fuel;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower 
        {
            get { return this.horsePower; } 
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be negative");
                }

                this.horsePower = value;
            } 
        }

        public double Fuel 
        {
            get { return this.fuel; }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel cannot ne negative!!!");
                }

                this.fuel = value;
            }
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            this.fuel -= (this.FuelConsumption * 100) / 100;
        }
    }
}
