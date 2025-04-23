using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Dictionary<char, int> dict = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            char symbol = text[i];

            if (symbol == ' ')
            {
                continue;
            }

            if (!dict.ContainsKey(symbol))
            {
                dict[symbol] = 0;
            }

            dict[symbol]++;
        }

        foreach (var cvp in dict)
        {
            Console.WriteLine($"{cvp.Key} -> {cvp.Value}");
        }
    }
}