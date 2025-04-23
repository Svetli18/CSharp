namespace CarManufacturer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();


            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            try
            {
                string tireCommand = null;
                while ((tireCommand = Console.ReadLine()) != "No more tires")
                {

                    var tireargs = tireCommand
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int ty1 = int.Parse(tireargs[0]);
                    double tp1 = double.Parse(tireargs[1]);
                    int ty2 = int.Parse(tireargs[2]);
                    double tp2 = double.Parse(tireargs[3]);
                    int ty3 = int.Parse(tireargs[4]);
                    double tp3 = double.Parse(tireargs[5]);
                    int ty4 = int.Parse(tireargs[6]);
                    double tp4 = double.Parse(tireargs[7]);

                    Tire tire1 = new Tire(ty1, tp1);
                    Tire tire2 = new Tire(ty2, tp2);
                    Tire tire3 = new Tire(ty3, tp3);
                    Tire tire4 = new Tire(ty4, tp4);

                    Tire[] tires = new Tire[] { tire1, tire2, tire3, tire4 };

                    tiresList.Add(tires);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Tires");
            }

            Console.WriteLine($"Tires time {stopwatch.Elapsed}");

            stopwatch.Start();

            try
            {
                string engineCommand = null;
                while ((engineCommand = Console.ReadLine()) != "Engines done")
                {
                    if (string.IsNullOrEmpty(engineCommand) || string.IsNullOrWhiteSpace(engineCommand))
                    {
                        continue;
                    }

                    var engineArgs = engineCommand
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int hp = int.Parse(engineArgs[0]);
                    double cc = double.Parse(engineArgs[1]);

                    Engine engine = new Engine(hp, cc);

                    engineList.Add(engine);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Engine");
            }

            Console.WriteLine($"Engine time {stopwatch.Elapsed}");

            stopwatch.Start();

            try
            {
                string carCommand = null;
                while ((carCommand = Console.ReadLine()) != "Show special")
                {
                    if (string.IsNullOrEmpty(carCommand) || string.IsNullOrWhiteSpace(carCommand))
                    {
                        continue;
                    }

                    var carArgs = carCommand
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string make = carArgs[0];
                    string model = carArgs[1];
                    int year = int.Parse(carArgs[2]);
                    double fuelQuantity = double.Parse(carArgs[3]);
                    double fuelConsumption = double.Parse(carArgs[4]);
                    int engineIndex = int.Parse(carArgs[5]);
                    int tiresIndex = int.Parse(carArgs[6]);

                    Engine engine = engineList[engineIndex];
                    Tire[] tires = tiresList[tiresIndex];
                    Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                    carList.Add(car);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Car");

            }

            Console.WriteLine($"Car time {stopwatch.Elapsed}");

            var specialCars = carList
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(t => t.Pressure) > 9)
                .Where(c => c.Tires.Sum(t => t.Pressure) < 10)
                .ToList();

            specialCars
                .ForEach(c => c.Drive(20.0));

            specialCars.ForEach(c => Console.WriteLine(c.WhoAmI()));

        }
    }
}