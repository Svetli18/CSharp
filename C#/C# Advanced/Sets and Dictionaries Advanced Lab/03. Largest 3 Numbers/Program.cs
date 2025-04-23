using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        HashSet<int> numbs = new HashSet<int>();

        foreach (var number in input)
        {
            numbs.Add(number);
        }

        numbs = numbs.OrderByDescending(n => n)
            .Take(3)
            .ToHashSet();

        Console.WriteLine($"{string.Join(' ', numbs)}");
    }
}