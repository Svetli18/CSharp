using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] names = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> namesOfRacers = new Dictionary<string, int>();
        AddRacers(names, namesOfRacers);

        Regex parrternNames = new Regex(@"[A-Za-z]+");
        Regex parrternKm = new Regex(@"\d");


        string command;
        while ((command = Console.ReadLine()) != "end of race")
        {
            string name = string.Concat(parrternNames.Matches(command)).ToString();

            if (namesOfRacers.ContainsKey(name))
            {
                namesOfRacers[name] += AddRacerKm(parrternKm, command);
            }
        }

        var sorted = namesOfRacers.OrderByDescending(r => r.Value)
            .Take(3)
            .ToList();

        Console.WriteLine($"1st place: {sorted[0].Key}");
        Console.WriteLine($"2nd place: {sorted[1].Key}");
        Console.WriteLine($"3rd place: {sorted[2].Key}");
    }

    static void AddRacers(string[] names, Dictionary<string, int> namesOfRacers)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (!namesOfRacers.ContainsKey(names[i]))
            {
                namesOfRacers[names[i]] = 0;
            }
        }
    }

    static int AddRacerKm(Regex parrternKm, string command)
    {

        return string.Concat(parrternKm.Matches(command))
            .Split()
            .Select(int.Parse)
            .Sum();
    }
}