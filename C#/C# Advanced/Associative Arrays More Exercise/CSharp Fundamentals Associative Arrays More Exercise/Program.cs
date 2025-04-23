using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var contests = new Dictionary<string, string>();
        var users = new SortedDictionary<string, Dictionary<string, int>>();

        var input = "";
        while ((input = Console.ReadLine()) != "end of contests")
        {
            var inputArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

            var contest = inputArgs[0];
            var password = inputArgs[1];

            if (!contests.ContainsKey(contest))
            {
                contests[contest] = password;
            }
        }

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            var inputArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            var contest = inputArgs[0];
            var password = inputArgs[1];
            var userName = inputArgs[2];
            var tryParse = int.TryParse(inputArgs[3], out int points);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }

                if (!users[userName].ContainsKey(contest))
                {
                    users[userName][contest] = points;
                }
                else if (users[userName][contest] < points)
                {
                    users[userName][contest] = points;
                }
            }
        }

        var best = users.OrderByDescending(u => u.Value.Values.Sum())
            .Take(1)
            .ToDictionary(u => u.Key, u => u.Value);

        var bestUser = best.Keys.FirstOrDefault();
        var besrPoints = best.Values.FirstOrDefault().Values.Sum();

        Console.WriteLine($"Best candidate is {bestUser} with total {besrPoints} points.");
        Console.WriteLine("Ranking:");

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Key}");

            foreach (var contest in user.Value.OrderByDescending(u => u.Value))
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }
}