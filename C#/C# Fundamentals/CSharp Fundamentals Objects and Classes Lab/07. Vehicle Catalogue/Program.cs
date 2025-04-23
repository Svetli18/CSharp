using System;
using System.Linq;
using System.Collections.Generic;

class Truck
{
    public Truck(string brand, string model, int weight)
    {
        Brand = brand;
        Model = model;
        Weight = weight;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
}

class Car
{
    public Car(string brand, string model, int horsePower)
    {
        Brand = brand;
        Model = model;
        HorsePower = horsePower;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}

class CatalogueVehicle
{
    public CatalogueVehicle()
    {
        Trucks = new List<Truck>();
        Cars = new List<Car>();
    }

    public List<Truck> Trucks { get; set; }

    public void AddTruck(Truck truck)
    {
        Trucks.Add(truck);
    }

    public List<Car> Cars { get; set; }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {

        CatalogueVehicle vehicles = new CatalogueVehicle();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandArguments = command
                .Split('/', StringSplitOptions.RemoveEmptyEntries);

            string typeVehicle = commandArguments[0];
            string brand = commandArguments[1];
            string model = commandArguments[2];
            int vehicleParameters = int.Parse(commandArguments[3]);

            if (typeVehicle == "Truck")
            {
                Truck truck = new Truck(brand, model, vehicleParameters);
                vehicles.Trucks.Add(truck);
            }
            else if (typeVehicle == "Car")
            {
                Car car = new Car(brand, model, vehicleParameters);
                vehicles.Cars.Add(car);

            }

        }

        if (0 < vehicles.Cars.Count)
        {
            Console.WriteLine("Cars:");
            vehicles.Cars
                .OrderBy(c => c.Brand)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Brand}: {c.Model} - {c.HorsePower}hp"));
        }

        if (0 < vehicles.Trucks.Count)
        {
            Console.WriteLine("Trucks:");
            vehicles.Trucks
                .OrderBy(t => t.Brand)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Brand}: {t.Model} - {t.Weight}kg"));
        }


    }
}