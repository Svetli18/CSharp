using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var students = new Dictionary<string, int>();
        var languages = new Dictionary<string, int>();

        var cmd = "";
        while ((cmd = Console.ReadLine()) != "exam finished")
        {
            var cmdArgs = cmd.Split('-', StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs.Length == 3)
            {
                var name = cmdArgs[0];
                var language = cmdArgs[1];
                var tryParse = int.TryParse(cmdArgs[2], out int points);

                if (tryParse)
                {
                    if (!students.ContainsKey(name))
                    {
                        students[name] = 0;
                    }
                    if (!languages.ContainsKey(language))
                    {
                        languages[language] = 0;
                    }

                    students[name] = points;
                    languages[language]++;
                }

            }
            else if (cmdArgs.Length == 2)
            {
                var name = cmdArgs[0];

                students.Remove(name);

            }

        }

        Console.WriteLine("Results:");
        students.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Key} | {x.Value}"));

        Console.WriteLine("Submissions:");
        languages.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Key} - {x.Value}"));

    }
}