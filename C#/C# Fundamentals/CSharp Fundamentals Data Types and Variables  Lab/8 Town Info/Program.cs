namespace TownInfo
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string populatin = Console.ReadLine();
            string area = Console.ReadLine();

            Console.WriteLine($"Town {town} has population of {populatin} and area {area} square km.");
        }
    }
}