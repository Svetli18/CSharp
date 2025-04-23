using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var continents = new Dictionary<string, Dictionary<string, List<string>>>();

        var tryToParse = int.TryParse(Console.ReadLine(), out int n);

        for (int i = 0; i < n; i++)
        {
            var current = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var continent = current[0];
            var country = current[1];
            var city = current[2];

            if (!continents.ContainsKey(continent))
            {
                continents[continent] = new Dictionary<string, List<string>>();
            }

            if (!continents[continent].ContainsKey(country))
            {
                continents[continent][country] = new List<string>();
            }

            continents[continent][country].Add(city);

        }

        foreach (var continent in continents)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
            }
        }

    }
}