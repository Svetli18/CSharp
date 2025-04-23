using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {

        Action<decimal> action = n => Console.WriteLine($"{n *= 1.2m:F2}");

        Console.ReadLine()
            .Split(new[] {' ', ',', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(decimal.Parse)
            .ToList()
            .ForEach(n => action(n));

    }
}