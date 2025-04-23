namespace PoundsToDollars
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());

            decimal result = pounds * 1.31M;

            Console.WriteLine($"{result:F3}");
        }
    }
}