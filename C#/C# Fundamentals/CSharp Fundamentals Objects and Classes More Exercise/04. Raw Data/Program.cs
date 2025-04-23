using System;
using System.Linq;
using System.Collections.Generic;

class Car
{
    public Car(string model, Engine engine, Cargo cargo)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }

    public override string ToString()
    {
        return $"{Model}";
    }
}

class Engine
{
    public Engine(int engineSpeed, int enginePower)
    {
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
    }

    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
}
class Cargo
{
    public Cargo(int cargoWeight, string cargoType)
    {
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }

    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
}
internal class Program
{
    private static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int n  = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentCar = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string carModel  = currentCar[0];
            int engineSpeed = int.Parse(currentCar[1]);
            int enginePower = int.Parse(currentCar[2]);
            int cargoWeight = int.Parse(currentCar[3]);
            string cargoType = currentCar[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            Car car = new Car(carModel, engine, cargo);
            cars.Add(car);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            var sortedCars = cars.Where(c => c.Cargo.CargoType.Equals(command)).ToList();
            sortedCars.Where(c => c.Cargo.CargoWeight < 1000)
                //.OrderBy(c => c.Model)
                .ToList()
                .ForEach(c => Console.WriteLine(c));
        }
        else if (command == "flamable")
        {
            var sortedCars = cars.Where(c => c.Cargo.CargoType.Equals(command)).ToList();
            sortedCars.Where(c => c.Engine.EnginePower > 250)
                //.OrderBy(c => c.Model)
                .ToList()
                .ForEach(c => Console.WriteLine(c));
        }
    }
}