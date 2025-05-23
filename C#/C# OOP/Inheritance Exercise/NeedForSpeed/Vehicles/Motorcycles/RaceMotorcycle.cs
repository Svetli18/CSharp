﻿namespace NeedForSpeed.Vehicles.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
