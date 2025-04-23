using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        var dict = new Dictionary<double, int>();

        for (int i = 0; i < input.Length; i++)
        {
            double current = input[i];

            if (!dict.ContainsKey(current))
            {
                dict[current] = 0;
            }

            dict[current]++;
        }

        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
        }
    }
}