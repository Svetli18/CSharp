using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var force = new Dictionary<string, SortedSet<string>>();

        var cmd = "";
        while ((cmd = Console.ReadLine()) != "Lumpawaroo")
        {

            if (cmd.Contains("|"))
            {
                var indexOf = cmd.IndexOf("|");
                var side = cmd.Substring(0, indexOf - 1);
                var name = cmd.Substring(indexOf + 2);

                if (!force.ContainsKey(side))
                {
                    force[side] = new SortedSet<string>();
                }

                force[side].Add(name);

            }
            else if (cmd.Contains("->"))
            {
                var indexOf = cmd.IndexOf("-");
                var side = cmd.Substring(indexOf + 3);
                var name = cmd.Substring(0, indexOf - 1);

                foreach (var fsp in force)
                {
                    if (force[fsp.Key].Contains(name) && force[side].Contains(name))
                    {
                        break;
                    }
                }

                foreach (var fsp in force)
                {
                    if (fsp.Key != side)
                    {
                        if (force[fsp.Key].Contains(name))
                        {
                            force[fsp.Key].Remove(name);
                        }

                        force[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                        break;
                    }
                }

            }

        }

        force = force.Where(x => x.Value.Count > 0)
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var svp in force)
        {
            Console.WriteLine($"Side: {svp.Key}, Members: {svp.Value.Count}");

            foreach (var kvp in svp.Value)
            {
                Console.WriteLine($"! {kvp}");
            }
        }

    }
}