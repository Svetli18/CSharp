using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = GetCars(n);

        string cmd;
        while((cmd = Console.ReadLine()) != "Stop")
        {
            var cmdArgs = cmd.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            var command = cmdArgs[0];
            var name = cmdArgs[1];

            if (command == "Drive")
            {
                var kilometers = int.Parse(cmdArgs[2]);
                var fuel = int.Parse(cmdArgs[3]);

                if(cars.ContainsKey(name))
                {
                    if (fuel <= cars[name].Fuel)
                    {
                        cars[name].Kilometers += kilometers;
                        cars[name].Fuel -= fuel;

                        Console.WriteLine($"{name} driven for {kilometers} kilometers. {fuel} liters of fuel consumed.");

                        if (100000 <= cars[name].Kilometers)
                        {
                            Console.WriteLine($"Time to sell the {name}!");
                            cars.Remove(name);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                }
            }
            else if (command == "Refuel")
            {
                var fuel = int.Parse(cmdArgs[2]);

                if(cars.ContainsKey(name))
                {
                    if (cars[name].Fuel + fuel <= 75)
                    {
                        cars[name].Fuel += fuel;
                    }
                    else
                    {
                        fuel = 75 - cars[name].Fuel;
                        cars[name].Fuel = 75;
                    }

                    Console.WriteLine($"{name} refueled with {fuel} liters");
                }
            }
            else if(command == "Revert")
            {
                var decreaseKilometers = int.Parse(cmdArgs[2]);

                if(cars.ContainsKey(name))
                {
                    if (10000 <= cars[name].Kilometers - decreaseKilometers)
                    {
                        cars[name].Kilometers -= decreaseKilometers;
                        Console.WriteLine($"{name} mileage decreased by {decreaseKilometers} kilometers");
                    }
                    else
                    {
                        cars[name].Kilometers = 10000;
                    }
                }
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Kilometers} kms, Fuel in the tank: {car.Value.Fuel} lt.");
        }

    }

    static Dictionary<string, Car> GetCars(int n)
    {
        var cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            var name = input[0];
            var kilometers = int.Parse(input[1]);
            var fuel = int.Parse(input[2]);

            if (!cars.ContainsKey(name))
            {
                Car car = new Car(kilometers, fuel);
                cars[name] = car;
            }
        }

        return cars;
    }
}

class Car
{
    public Car(int kilometers, int fuel)
    {
        this.Kilometers = kilometers;
        this.Fuel = fuel;
    }

    public int Kilometers { get; set; }
    public int Fuel { get; set; }
}