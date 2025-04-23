namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();

            int cnt = 0;
            string command;

            try
            {
                while ((command = Console.ReadLine()) != "No more tires")
                {
                    var tireArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    bool boolTY1 = int.TryParse(tireArgs[0], out int ty1);
                    bool boolTP1 = double.TryParse(tireArgs[1], out double tp1);
                    bool boolTY2 = int.TryParse(tireArgs[2], out int ty2);
                    bool boolTP2 = double.TryParse(tireArgs[3], out double tp2);
                    bool boolTY3 = int.TryParse(tireArgs[4], out int ty3);
                    bool boolTP3 = double.TryParse(tireArgs[5], out double tp3);
                    bool boolTY4 = int.TryParse(tireArgs[6], out int ty4);
                    bool boolTP4 = double.TryParse(tireArgs[7], out double tp4);

                    Tire[] tiresArray = new Tire[]
                    {
                    new Tire(ty1, tp1),
                    new Tire(ty2, tp2),
                    new Tire(ty3, tp3),
                    new Tire(ty4, tp4)
                    };

                    tiresList.Add(tiresArray);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Tires");
            }

            try
            {
                while ((command = Console.ReadLine()) != "Engines done")
                {
                    var engineArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    bool boolHP = int.TryParse(engineArgs[0], out int hp);
                    bool boolCC = double.TryParse(engineArgs[1], out double cc);

                    Engine engine = new Engine(hp, cc);

                    engineList.Add(engine);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Engine");
            }

            try
            {
                while ((command = Console.ReadLine()) != "Show special")
                {
                    var carArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string make = carArgs[0];
                    string model = carArgs[1];
                    bool boolYear = int.TryParse(carArgs[2], out int year);
                    bool boolFuelQuantity = double.TryParse(carArgs[3], out double fuelQuantity);
                    bool boolFuelConsumption = double.TryParse(carArgs[4], out double fuelConsumption);
                    bool boolEngineIndex = int.TryParse(carArgs[5], out int engineIndex);
                    bool boolTiresIndex = int.TryParse(carArgs[6], out int tiresIndex);

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