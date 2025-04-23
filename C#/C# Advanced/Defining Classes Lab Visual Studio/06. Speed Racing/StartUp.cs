namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumption = double.Parse(carArgs[2]) * 100;

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars[model] = car;

            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] carArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currCommand = carArgs[0];

                if (currCommand == "Drive")
                {
                    string model = carArgs[1];
                    double km = double.Parse(carArgs[2]);

                    cars[model].Drive(km);
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}
