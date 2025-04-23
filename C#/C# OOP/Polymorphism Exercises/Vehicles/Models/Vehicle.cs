namespace Vehicles.Models
{
    using Vehicles.Contracts;

    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const double TruckGivenFuel = 0.95;

        private double fuelQuantity;

        private double fuelConsumption;

        private int tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel quantity cannot be negative!");
                }

                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArithmeticException("Fuel Consumtion cannot be zero or negative!");
                }

                this.fuelConsumption = value;
            }
        }

        public int TankCapacity
        {
            get { return this.tankCapacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Tank capacity cannot be zero or negative!");
                }

                this.tankCapacity = value;

                if (this.TankCapacity < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }
            }
        }

        public virtual string Drive(double distance)
        {
            double currentQuantity = this.FuelQuantity;
            currentQuantity -= this.FuelConsumption * distance;

            if (currentQuantity <= 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity = currentQuantity;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity < this.fuelQuantity + liters)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                if (this.GetType().Name == "Truck")
                {
                    liters *= TruckGivenFuel;
                }

                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
