using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var judge = new Dictionary<string, Dictionary<string, int>>();
        var individual = new SortedDictionary<string, int>();

        var input = "";
        while ((input = Console.ReadLine()) != "no more time")
        {
            var inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            var contest = inputArgs[1];
            var userName = inputArgs[0];
            var tryParse = int.TryParse(inputArgs[2], out int points);

            if (!judge.ContainsKey(contest))
            {
                judge[contest] = new Dictionary<string, int>();
            }

            if (!judge[contest].ContainsKey(userName))
            {
                judge[contest][userName] = points;
            }
            else if (judge[contest][userName] < points)
            {
                judge[contest][userName] = points;
            }

        }

        ;
        foreach (var contest in judge.OrderByDescending(u => u.Value.Sum(c => c.Value)).ThenBy(c => c.Key))
        {
            ;
            Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
            var number = 1;

            foreach (var user in contest.Value.OrderByDescending(u => u.Value))
            {
                Console.WriteLine($"{number++}. {user.Key} <::> {user.Value}");

                if (!individual.ContainsKey(user.Key))
                {
                    individual[user.Key] = user.Value;
                    continue;
                }

                individual[user.Key] += user.Value;

            }
        }

        Console.WriteLine("Individual standings:");
        var numb = 1;

        foreach (var user in individual.OrderByDescending(u => u.Value))
        {
            Console.WriteLine($"{numb++}. {user.Key} -> {user.Value}");
        }
    }
}