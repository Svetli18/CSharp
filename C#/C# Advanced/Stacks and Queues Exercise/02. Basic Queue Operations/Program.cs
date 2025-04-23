using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var cmd = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var n = cmd[1];
        var specialElement = cmd[2];

        var queue = new Queue<int>(input);

        for (int i = 0; i < n && queue.Any(); i++)
        {
            queue.Dequeue();
        }

        if (!queue.Any())
        {
            Console.WriteLine(0);
        }
        else if (queue.Contains(specialElement))
        {
            Console.WriteLine("true");
        }
        else if (!queue.Contains(specialElement))
        {
            Console.WriteLine(queue.Min());
        }
    }
}