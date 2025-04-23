using System;
using System.Linq;
using System.Collections.Generic;

class Vehicle
{
    public Vehicle()
    {
        Cars = new List<Car>();
        Trucks = new List<Truck>();
    }
    public List<Car> Cars { get; set; }
    public List<Truck>  Trucks { get; set; }

    public float AverageCarsHorsepower(List<Car> cars)
    {
        float result = 0;
        for (int i = 0; i < cars.Count; i++)
        {
            result += cars[i].Horsepower;
        }
        return result / cars.Count;
    }

    public float AverageTruckHorsepower(List<Truck> cars)
    {
        float result = 0;
        for (int i = 0; i < cars.Count; i++)
        {
            result += cars[i].Horsepower;
        }
        return result / cars.Count;
    }

}

class Car
{
    public Car(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }

    public override string ToString()
    {
        return $"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
    }
}
class Truck
{
    public Truck(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }

    public override string ToString()
    {
        return $"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Vehicle vehicles = new Vehicle();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] currentVehicle = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = currentVehicle[0];
            string model = currentVehicle[1];
            string color = currentVehicle[2];
            int horsePower = int.Parse(currentVehicle[3]);

            if (type == "car")
            {
                Car car = new Car("Car", model, color, horsePower);
                vehicles.Cars.Add(car);

            }
            else if (type == "truck")
            {
                Truck truck = new Truck("Truck", model, color, horsePower);
                vehicles.Trucks.Add(truck);
            }
        }

        string vehicle;
        while ((vehicle = Console.ReadLine()) != "Close the Catalogue")
        {
            Car car = vehicles.Cars.Find(c => c.Model == vehicle);

            if (car != null)
            {
                Console.WriteLine(car);
            }

            Truck truck = vehicles.Trucks.Find(t => t.Model == vehicle);

            if (truck != null)
            {
                Console.WriteLine(truck);
            }
        }

        if (vehicles.Cars.Any())
        {
            Console.WriteLine($"Cars have average horsepower of: {vehicles.AverageCarsHorsepower(vehicles.Cars):F2}.");
        }

        if (vehicles.Trucks.Any())
        {
            Console.WriteLine($"Trucks have average horsepower of: {vehicles.AverageTruckHorsepower(vehicles.Trucks):F2}.");
        }
    }
}