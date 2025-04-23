using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var vloggerAndHisFollowers = new Dictionary<string, SortedSet<string>>();
        var vloggerFollowVloggers = new Dictionary<string, HashSet<string>>();

        var command = "";
        while ((command = Console.ReadLine()) != "Statistics")
        {
            var commandArgs = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var currentVlogger = commandArgs[0];
            var currCommand = commandArgs[1];

            if (currCommand == "joined" &&
                !vloggerAndHisFollowers.ContainsKey(currentVlogger))
            {
                vloggerAndHisFollowers[currentVlogger] = new SortedSet<string>();
                vloggerFollowVloggers[currentVlogger] = new HashSet<string>();
            }

            if (currCommand == "followed")
            {
                var theVloger = commandArgs[2];

                if (currentVlogger != theVloger &&
                    vloggerAndHisFollowers.ContainsKey(currentVlogger) &&
                    vloggerFollowVloggers.ContainsKey(theVloger))
                {
                    vloggerAndHisFollowers[theVloger].Add(currentVlogger);
                    vloggerFollowVloggers[currentVlogger].Add(theVloger);
                }
            }

        }

        Console.WriteLine($"The V-Logger has a total of {vloggerAndHisFollowers.Count} vloggers in its logs.");

        var result = vloggerAndHisFollowers
            .OrderByDescending(v => v.Value.Count)
            .ThenBy(v => vloggerFollowVloggers[v.Key].Count)
            .ToDictionary(k => k.Key, v => v.Value);

        var biggestVlogger = result.Take(1)
            .ToDictionary(k => k.Key, v => v.Value);

        var otherVlogers = result.Skip(1)
            .ToDictionary(k => k.Key, v => v.Value);

        var c = 1;


        var name = "";
        var followers = 0;
        var followings = 0;

        foreach (var kvp in biggestVlogger)
        {
            name = kvp.Key;
            followers  = biggestVlogger[kvp.Key].Count;
            followings = vloggerFollowVloggers[kvp.Key].Count;

            Console.WriteLine($"{c++}. {name} : {followers} followers, {followings} following");

            foreach (var current in kvp.Value)
            {
                Console.WriteLine($"*  {current}");
            }
        }

        foreach (var kvp in otherVlogers)
        {
            name = kvp.Key;
            followers = vloggerAndHisFollowers[kvp.Key].Count;
            followings = vloggerFollowVloggers[kvp.Key].Count;

            Console.WriteLine($"{c++}. {name} : {followers} followers, {followings} following");
        }

    }
}