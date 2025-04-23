using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();

        List<string> output = new List<string>();

        Regex pattern = new Regex(@"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1");

        MatchCollection matches = pattern.Matches(input);

        if (matches != null)
        {
            foreach (Match match in matches)
            {
                var firstString = match.Groups[2].Value;
                var secondString = match.Groups[3].Value;

                var isMirror = GetIsMirror(firstString, secondString);

                if (isMirror)
                {
                    output.Add(firstString + " <=> " + secondString);
                }
            }
        }

        if (0 < matches.Count)
        {
            Console.WriteLine($"{matches.Count} word pairs found!");
        }
        else
        {
            Console.WriteLine("No word pairs found!");
        }

        if (0 < output.Count)
        {
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", output));
        }
        else
        {
            Console.WriteLine("No mirror words!");
        }

    }

    static bool GetIsMirror(string firstString, string secondString)
    {
        bool isMirror = true;

        if (firstString.Length != secondString.Length)
        {
            return false;
        }

        for (int i = 0; i < firstString.Length; i++)
        {
            var firstCh = firstString[i];
            var secondCh = secondString[firstString.Length - 1 - i];

            if (firstCh != secondCh)
            {
                isMirror = false;
                break;
            }
        }

        return isMirror;
    }
}