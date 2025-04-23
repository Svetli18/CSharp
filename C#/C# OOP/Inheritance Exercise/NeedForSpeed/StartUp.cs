namespace NeedForSpeed
{
    using NeedForSpeed.Vehicles;
    using NeedForSpeed.Vehicles.Cars;
    using NeedForSpeed.Vehicles.Motorcycles;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new RaceMotorcycle(150, 100);

            vehicle.Drive(100);

            Console.WriteLine(vehicle.Fuel);
        }
    }
}
