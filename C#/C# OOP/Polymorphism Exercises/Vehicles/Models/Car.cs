namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncreaseFuelConsumprion = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption += IncreaseFuelConsumprion, tankCapacity)
        {

        }
    }
}
