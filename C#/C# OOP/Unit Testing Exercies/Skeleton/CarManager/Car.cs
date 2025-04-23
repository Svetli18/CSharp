using System;

namespace CarManager
{
    public class Car
    {
        private string make;

        private string model;

        private double fuelConsumption;

        private double fuelAmount;

        private double fuelCapacity;

        private Car()
        {
            this.FuelAmount = 0;
        }

        public Car(string make, string model, double fuelConsumption, double fuelCapacity) : this()
        {
            this.Make = make;
            this.Model = model;
            this.FuelConsumption = fuelConsumption;
            this.FuelCapacity = fuelCapacity;
        }
        //ok
        public string Make
        {   //ok
            get
            {
                return this.make;
            }
            private set
            {   //ok
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Make cannot be null or empty!");
                }
                //ok
                this.make = value;
            }
        }
        //ok
        public string Model
        {   //ok
            get
            {
                return this.model;
            }
            private set
            {   //ok
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null or empty!");
                }
                //ok
                this.model = value;
            }
        }
        //ok
        public double FuelConsumption
        {   //ok
            get
            {   
                return this.fuelConsumption;
            }
            private set
            {   //ok
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be zero or negative!");
                }
                //ok
                this.fuelConsumption = value;
            }
        }
        //ok
        public double FuelAmount
        {   //ok
            get
            {
                return this.fuelAmount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel amount cannot be negative!");
                }
                //ok
                this.fuelAmount = value;
            }
        }
        //ok
        public double FuelCapacity
        {   //ok
            get
            {
                return this.fuelCapacity;
            }
            private set
            {   //ok
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel capacity cannot be zero or negative!");
                }
                //ok
                this.fuelCapacity = value;
            }
        }
        //ok
        public void Refuel(double fuelToRefuel)
        {   //ok
            if (fuelToRefuel <= 0)
            {
                throw new ArgumentException("Fuel amount cannot be zero or negative!");
            }
            //ok
            this.FuelAmount += fuelToRefuel;
            //ok
            if (this.FuelAmount > this.FuelCapacity)
            {
                this.FuelAmount = this.FuelCapacity;
            }
        }
        //ok
        public void Drive(double distance)
        {   
            double fuelNeeded = (distance / 100) * this.FuelConsumption;
            //ok
            if (fuelNeeded > this.FuelAmount)
            {
                throw new InvalidOperationException("You don't have enough fuel to drive!");
            }
            //ok
            this.FuelAmount -= fuelNeeded;
        }
    }
}
