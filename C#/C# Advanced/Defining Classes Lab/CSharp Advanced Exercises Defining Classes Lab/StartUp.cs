namespace CarManufacturer
{
    using System;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine(car);


            //string make = "BMW";
            //string model = "X5";
            //int year = DateTime.Now.Year;

            //car = new Car(make, model, year);

            //Console.WriteLine(car);
        }
    }
}