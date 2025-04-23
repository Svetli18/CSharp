using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var names = new HashSet<string>();

        var tryParse = int.TryParse(Console.ReadLine(), out int n);

        for (int i = 0; i < n; i++)
        {
            var current = Console.ReadLine();

            names.Add(current);

        }

        Console.WriteLine(string.Join(Environment.NewLine, names));

    }
}