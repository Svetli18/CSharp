using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var towns = GetTowns();

        var cmd = "";
        while((cmd = Console.ReadLine()) != "End")
        {
            var cmdArgs = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            var commad = cmdArgs[0];
            var townName = cmdArgs[1];

            if(commad == "Plunder")
            {
                var people = int.Parse(cmdArgs[2]);
                var gold = int.Parse(cmdArgs[3]);

                towns[townName].Population -= people;
                towns[townName].Gold -= gold;
                Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                if (towns[townName].Population <= 0 || 
                    towns[townName].Gold <= 0)
                {
                    towns.Remove(townName);
                    Console.WriteLine($"{townName} has been wiped off the map!");
                }

            }
            else if(commad == "Prosper")
            {
                var gold = int.Parse(cmdArgs[2]);

                if(gold <= 0)
                {
                    Console.WriteLine("Gold added cannot be a negative number!");
                    continue;
                }

                towns[townName].Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {towns[townName].Gold} gold.");

            }
        }

        if(0 < towns.Count)
        {
            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

            foreach (var town in towns)
            {
                Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
            }

        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }

    }

    static Dictionary<string, Town> GetTowns()
    {
        var towns = new Dictionary<string, Town>();

        var cmd = "";
        while((cmd = Console.ReadLine()) != "Sail")
        {
            var cmdArgs = cmd.Split("||", StringSplitOptions.RemoveEmptyEntries);

            var townName = cmdArgs[0];
            var population = int.Parse(cmdArgs[1]);
            var gold = int.Parse(cmdArgs[2]);

            if (!towns.ContainsKey(townName))
            {
                Town town = new Town(population, gold);
                towns[townName] = town;
                continue;
            }

            towns[townName].Population += population;
            towns[townName].Gold += gold;

        }

        return towns;
    }
}

class Town
{
    public Town(int population, int gold)
    {
        Population = population;
        Gold = gold;
    }

    public int Population { get; set; }
    public int Gold { get; set; }
}