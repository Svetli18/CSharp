using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        string resource;
        while ((resource = Console.ReadLine()) != "stop")
        {
            int quantity = int.Parse(Console.ReadLine());

            if (!dict.ContainsKey(resource))
            {
                dict[resource] = 0;
            }

            dict[resource] += quantity;

        }

        foreach (var mqp in dict)
        {
            Console.WriteLine($"{mqp.Key} -> {mqp.Value}");
        }
    }
}