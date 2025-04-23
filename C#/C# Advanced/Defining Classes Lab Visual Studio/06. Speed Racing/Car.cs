
namespace CarManufacturer
{
    using System;

    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public Car()
        {
        }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public string Model { get => this.model; set => this.model = value; }

        public double FuelAmount { get => this.fuelAmount; set => this.fuelAmount = value; }

        public double FuelConsumption { get => this.fuelConsumption; set => this.fuelConsumption = value; }

        public double TravelledDistance { get => this.travelledDistance; }

        public void Drive(double km)
        {
            bool isTravel = this.FuelAmount - ((km * this.FuelConsumption) / 100) >= 0;

            if (isTravel)
            {
                this.travelledDistance += km;
                this.FuelAmount -= ((km * this.FuelConsumption) / 100);
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
