using System;
using System.Collections.Generic;

class Car
{
    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumption = fuelConsumption * 100;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double TraveledDistance { get; set; }

    public void CalculateDrive(double km)
    {
        double result = FuelAmount - (FuelConsumption * km) / 100;

        if (result < 0)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelAmount = result;
            TraveledDistance += km;
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {TraveledDistance}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentCar = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = currentCar[0];
            double fuelAmount = double.Parse(currentCar[1]);
            double fuelConsumption = double.Parse(currentCar[2]);

            Car car = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] currentCommand = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string cmd = currentCommand[0];

            if (cmd == "Drive")
            {
                string model = currentCommand[1];
                double km = double.Parse(currentCommand[2]);

                Car car = cars.Find(c => c.Model.Equals(model));

                car.CalculateDrive(km);
            }
        }

        cars.ForEach(c => Console.WriteLine(c));
    }
}