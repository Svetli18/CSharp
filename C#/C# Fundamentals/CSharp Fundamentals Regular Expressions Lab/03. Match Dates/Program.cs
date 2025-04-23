using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Regex pattern = new Regex(@"(\d{2})([-\/\.])([A-Z][a-z]{2})\2(\d{4})");

        MatchCollection matches = pattern.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine($"Day: {match.Groups[1]}, Month: {match.Groups[3]}, Year: {match.Groups[4]}");
        }
    }
}