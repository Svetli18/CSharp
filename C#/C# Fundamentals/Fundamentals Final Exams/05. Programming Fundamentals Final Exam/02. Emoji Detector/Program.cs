using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var cools = new Dictionary<string, int>();

        Regex coolRegex = new Regex(@"[0-9]");
        MatchCollection numbers = coolRegex.Matches(text);

        var coolNumber = 0;

        if (numbers != null)
        {
            coolNumber = GetCoolNumber(numbers);
        }

        Regex regex = new Regex(@"(:{2}|\*{2})([A-Z][a-z]{2,})\1");
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            var matchValue = GetMatchValue(match.Groups[2].Value);

            if (coolNumber <= matchValue)
            {
                cools[match.Value] = matchValue;
            }
        }

        Console.WriteLine($"Cool threshold: {coolNumber}");
        Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
        foreach (var kvp in cools)
        {
            Console.WriteLine(kvp.Key);
        }

    }

    static int GetMatchValue(string value)
    {
        var result = 0;

        for (int i = 0; i < value.Length; i++)
        {
            result += value[i];
        }

        return result;
    }

    static int GetCoolNumber(MatchCollection numbers)
    {
        var coolNumber = 1;

        foreach (Match match in numbers)
        {
            coolNumber *= int.Parse(match.Value);
        }

        return coolNumber;
    }
}