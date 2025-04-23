using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var tryParse = int.TryParse(Console.ReadLine(), out var n);

        var elements = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            var currentElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < currentElements.Length; j++)
            {
                elements.Add(currentElements[j]);
            }
        }

        Console.WriteLine(string.Join(' ', elements));

    }
}