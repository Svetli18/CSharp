
namespace CarManufacturer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];

                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1pressure = double.Parse(carArgs[5]);
                int tire1year = int.Parse(carArgs[6]);
                double tire2pressure = double.Parse(carArgs[7]);
                int tire2year = int.Parse(carArgs[8]);
                double tire3pressure = double.Parse(carArgs[9]);
                int tire3year = int.Parse(carArgs[10]);
                double tire4pressure = double.Parse(carArgs[11]);
                int tire4year = int.Parse(carArgs[12]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1pressure, tire1year),
                    new Tire(tire2pressure, tire2year),
                    new Tire(tire3pressure, tire3year),
                    new Tire(tire4pressure, tire4year)
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);

            }

            string typeCars = Console.ReadLine();

            if (typeCars == "flammable")
            {
                cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
            }
            else if (typeCars == "fragile")
            {
                cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(c => c.Pressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
            }

        }
    }
}
