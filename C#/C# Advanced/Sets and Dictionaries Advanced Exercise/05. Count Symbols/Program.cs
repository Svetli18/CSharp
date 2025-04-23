using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var symbols = new SortedDictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            var curr = input[i];

            if (!symbols.ContainsKey(curr))
            {
                symbols[curr] = 0;
            }

            symbols[curr]++;
        }

        foreach (var symbol in symbols)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}