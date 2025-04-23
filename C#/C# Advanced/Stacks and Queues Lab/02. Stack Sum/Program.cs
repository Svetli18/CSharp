using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var numbs = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var stack = new Stack<int>(numbs);

        var cmd = "";
        while ((cmd = Console.ReadLine().ToLower()) != "end")
        {
            var cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = cmdArgs[0];

            if (command == "add")
            {
                bool tryParseNumb1 = int.TryParse(cmdArgs[1], out var numb1);
                bool tryParseNumb2 = int.TryParse(cmdArgs[2], out var numb2);

                if (tryParseNumb1 && tryParseNumb2)
                {
                    stack.Push(numb1);
                    stack.Push(numb2);
                }

            }
            else if (command == "remove")
            {
                bool tryParseCount = int.TryParse(cmdArgs[1],out var count);

                if (tryParseCount && count <= stack.Count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        stack.Pop();
                    }
                }
            }
        }

        Console.WriteLine($"Sum: {stack.Sum()}");

    }
}