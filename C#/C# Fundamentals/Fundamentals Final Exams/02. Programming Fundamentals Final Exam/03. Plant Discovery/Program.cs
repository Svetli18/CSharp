using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var plants = new Dictionary<string, int>();
        var plantsList = new Dictionary<string, List<int>>();
        var plantsAverigeResult = new Dictionary<string, double>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
           .Split(new char[] { '<', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

            var plant = input[0];
            var rarity = int.Parse(input[1]);

            if (!plants.ContainsKey(plant))
            {
                plants[plant] = rarity;
                plantsList[plant] = new List<int>();
                plantsAverigeResult[plant] = 0;
                continue;
            }

            plants[plant] = rarity;
        }

        var cmd = "";
        while ((cmd = Console.ReadLine()) != "Exhibition")
        {
            var cmdArgs = cmd.Split(": ", StringSplitOptions.RemoveEmptyEntries);
            var command = cmdArgs[0];

            if (command == "Rate")
            {
                var commandArgs = cmdArgs[1]
                    .Split(" - ",StringSplitOptions.RemoveEmptyEntries);

                var plant = commandArgs[0];
                var rarity = int.Parse(commandArgs[1]);

                if (!plantsList.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                plantsList[plant].Add(rarity);

            }
            else if (command == "Update")
            {
                var commandArgs = cmdArgs[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var plant = commandArgs[0];
                var newRarity = int.Parse(commandArgs[1]);

                if (!plantsList.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                plants[plant] = newRarity;

            }
            else if (command == "Reset")
            {
                var plant = cmdArgs[1];

                if (!plantsList.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                plantsList[plant].Clear();

            }
        }

        Console.WriteLine("Plants for the exhibition:");

        foreach (var kvp in plants)
        {
            if (0 < plantsList[kvp.Key].Count())
            {
                double sum = plantsList[kvp.Key].Sum();
                var count = plantsList[kvp.Key].Count();
                double result  = sum / count;
                plantsAverigeResult[kvp.Key] = result;
            }

        }

        foreach (var kvp in plants)
        {
            Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value}; Rating: {plantsAverigeResult[kvp.Key]:F2}");
        }

    }
}