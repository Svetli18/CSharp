namespace ConvertMetersToKilometers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());

            double result = meters / 1000.0;

            Console.WriteLine($"{result:F2}");
        }
    }
}