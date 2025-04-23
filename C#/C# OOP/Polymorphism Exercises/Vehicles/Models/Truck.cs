namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreaseFuelConsumprion = 1.6;       

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption += IncreaseFuelConsumprion, tankCapacity)
        {

        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
