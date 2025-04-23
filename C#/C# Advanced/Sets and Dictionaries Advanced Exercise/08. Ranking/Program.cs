using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var contests = new Dictionary<string, string>();
        var usersAndContests = new SortedDictionary<string, Dictionary<string, int>>();


        var cmd = "";
        while ((cmd = Console.ReadLine()) != "end of contests")
        {
            var cmdArgs = cmd.Split(':', StringSplitOptions.RemoveEmptyEntries);

            var contest = cmdArgs[0];
            var password = cmdArgs[1];

            if (!contests.ContainsKey(contest))
            {
                contests[contest] = password;
            }
        }

        while ((cmd = Console.ReadLine()) != "end of submissions")
        {
            var cmdArgs = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            var contest = cmdArgs[0];
            var password = cmdArgs[1];
            var name = cmdArgs[2];
            var tryParse = int.TryParse(cmdArgs[3], out int points);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (!usersAndContests.ContainsKey(name))
                {
                    usersAndContests[name] = new Dictionary<string, int>();
                }

                if (!usersAndContests[name].ContainsKey(contest))
                {
                    usersAndContests[name][contest] = 0;
                }

                if (usersAndContests[name][contest] < points)
                {
                    usersAndContests[name][contest] = points;
                }

            }
        }

        var userName = "";
        var theBest = usersAndContests.Values
            .OrderByDescending(u => u.Values.Sum())
            .FirstOrDefault();

        var theBestPoints = theBest.Values.Sum();
        var IsFaund = false;

        foreach (var user in usersAndContests)
        {
            var currentPoints = 0;

            foreach (var contest in user.Value)
            {
                currentPoints += contest.Value;

                if (currentPoints == theBestPoints)
                {
                    userName = user.Key;
                    IsFaund = true;
                    break;
                }
            }

            if (IsFaund)
            {
                break;
            }
        }

        Console.WriteLine($"Best candidate is {userName} with total {theBestPoints} points.");
        Console.WriteLine("Ranking:");

        foreach (var user in usersAndContests)
        {
            Console.WriteLine($"{user.Key}");

            foreach (var contest in user.Value.OrderByDescending(u => u.Value))
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }

        }
    }
}