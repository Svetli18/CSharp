using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            int carTankCapacity = int.Parse(carArgs[3]);

            Vehicle car = 
                new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            int truckTankCapacity = int.Parse(truckArgs[3]);

            Vehicle truck = 
                new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busArgs[1]);
            double busFuelConsumption = double.Parse(busArgs[2]);
            int busTankCapacity = int.Parse(busArgs[3]);

            Bus bus = 
                new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (command[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (command[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (command[0] == "DriveEmpty")
                {
                    double distance = double.Parse(command[2]);

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
                else if (command[0] == "Refuel")
                {
                    double refuel = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        car.Refuel(refuel);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(refuel);
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Refuel(refuel);                        
                    }
                }                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}