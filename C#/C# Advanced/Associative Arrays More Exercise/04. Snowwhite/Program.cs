using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var dwarfs = new Dictionary<string, Dictionary<string, int>>();

        var input = "";
        while ((input = Console.ReadLine()) != "Once upon a time")
        {
            var inputArgs = input
                .Split(new[] { ' ', '<', ':', '>' }, StringSplitOptions.RemoveEmptyEntries);

            var dwarfHatColor = inputArgs[1];
            var dwarfName = inputArgs[0];
            var tryParse = int.TryParse(inputArgs[2], out int dwarfPhysics);

            if (!dwarfs.ContainsKey(dwarfHatColor))
            {
                dwarfs[dwarfHatColor] = new Dictionary<string, int>();
            }

            if (!dwarfs[dwarfHatColor].ContainsKey(dwarfName))
            {
                dwarfs[dwarfHatColor][dwarfName] = dwarfPhysics;
            }
            else if (dwarfs[dwarfHatColor][dwarfName] < dwarfPhysics)
            {
                dwarfs[dwarfHatColor][dwarfName] = dwarfPhysics;
            }
        }

        var result = dwarfs
            .OrderByDescending(d => d.Value.OrderByDescending(x => x.Value));

        foreach (var cvp in dwarfs
            .OrderByDescending(d => d.Value.Values.FirstOrDefault())
            .ThenByDescending(d => d.Value.Count))
        {
            foreach (var dvp in cvp.Value)
            {
                Console.WriteLine($"({cvp.Key}) {dvp.Key} <-> {dvp.Value}");
            }
        }

    }
}