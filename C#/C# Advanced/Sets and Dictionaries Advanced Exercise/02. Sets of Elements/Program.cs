using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var ints = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var n1 = ints[0];
        var n2 = ints[1];

        var first = new HashSet<int>();
        var second = new HashSet<int>();

        for (int i = 0; i < n1 + n2; i++)
        {
            var current = int.Parse(Console.ReadLine());

            if (i < n1)
            {
                first.Add(current);
            }

            second.Add(current);

        }

        if (first.Count < second.Count)
        {
            foreach (var current in second)
            {
                if (first.Contains(current))
                {
                    Console.Write($"{current} ");
                }
            }
        }
        else
        {
            foreach (var current in first)
            {
                if (second.Contains(current))
                {
                    Console.Write($"{current} ");
                }
            }
        }
    }
}