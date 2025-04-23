using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] text = Console.ReadLine()
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        for (int i = 0; i < text.Length; i++)
        {
            string currentWord = text[i];

            if (!dict.ContainsKey(currentWord))
            {
                dict[currentWord] = 0;
            }

            dict[currentWord]++;
        }

        var sorted = dict.Where(v => v.Value % 2 != 0)
            .ToDictionary(k => k.Key, v => v.Value);

        Console.WriteLine(string.Join(' ', sorted.Keys));
    }
}