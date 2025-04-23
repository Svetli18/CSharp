using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < input.Length; i++)
        {
            int currNumber = input[i];

            if (!dict.ContainsKey(currNumber))
            {
                dict[currNumber] = 0;
            }

            dict[currNumber]++;
        }

        var sorted = dict.OrderBy(k => k.Key)
            .ThenByDescending(v => v.Value)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach (var kvp in sorted)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}