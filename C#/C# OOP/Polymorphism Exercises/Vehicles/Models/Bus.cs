namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double IncreaseFuelConsumprion = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }

        public override string Drive(double distance)
        {
            double currentQuantity = this.FuelQuantity;
            currentQuantity -= (this.FuelConsumption + IncreaseFuelConsumprion) * distance;

            //this.FuelConsumption -= IncreaseFuelConsumprion;

            if (currentQuantity <= 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity = currentQuantity;

            return $"{this.GetType().Name} travelled {distance} km";
        }        
    }
}
