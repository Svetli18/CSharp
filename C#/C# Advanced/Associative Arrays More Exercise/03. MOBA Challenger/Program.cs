using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var players = new SortedDictionary<string, Dictionary<string, int>>();

        var input = "";
        while ((input = Console.ReadLine()) != "Season end")
        {
            var inputArgumets = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var player = inputArgumets[0];
            var command = inputArgumets[1];

            if (command == "->")
            {
                var position = inputArgumets[2];
                var tryParse = int.TryParse(inputArgumets[4], out int skill);

                if (!players.ContainsKey(player))
                {
                    players[player] = new Dictionary<string, int>();
                }

                if (!players[player].ContainsKey(position))
                {
                    players[player][position] = skill;
                }
                else if (players[player][position] < skill)
                {
                    players[player][position] = skill;
                }

                continue;

            }

            var player2 = inputArgumets[2];
            if (command == "vs" && players.ContainsKey(player) && players.ContainsKey(player2))
            {
                var p1 = players[player].Values.Sum(p => p);
                var p2 = players[player2].Values.Sum(p => p);
                var pvp = false;

                foreach (var pvk in players[player])
                {
                    if (players[player2].ContainsKey(pvk.Key))
                    {
                        pvp = true;
                    }
                }

                if (pvp && p1 < p2)
                {
                    players.Remove(player);
                }
                else if(pvp && p2 < p1)
                {
                    players.Remove(player2);
                }

            }

        }

        foreach (var kvp in players.OrderByDescending(p => p.Value.Values.Sum()))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

            foreach (var pvp in kvp.Value.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"- {pvp.Key} <::> {pvp.Value}");
            }
        }

    }
}