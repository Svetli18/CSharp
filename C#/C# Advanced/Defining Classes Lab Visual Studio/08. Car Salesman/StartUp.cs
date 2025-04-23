namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                Engine engine = null;

                if (engineArgs.Length == 4)
                {
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];

                    engine = new Engine(model, power, displacement, efficiency);

                }
                else if (engineArgs.Length == 3)
                {
                    bool isInteger = int.TryParse(engineArgs[2], out int displacement);
                    if (isInteger)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArgs[2]);
                    }
                }
                else if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (!engines.ContainsKey(model))
                {
                    engines[model] = engine;
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                string engineName = carArgs[1];
                Engine engine = engines[engineName];

                Car car = null;

                if (carArgs.Length == 4)
                {
                    int weight = int.Parse(carArgs[2]);
                    string color = carArgs[3];

                    car = new Car(model, engine, weight, color);

                }
                else if (carArgs.Length == 3)
                {
                    bool isInteger = int.TryParse(carArgs[2], out int weight);

                    if (isInteger)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArgs[2]);
                    }

                }
                else if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }

                if (!cars.ContainsKey(model))
                {
                    cars[model] = car;
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }

        }
    }
}
