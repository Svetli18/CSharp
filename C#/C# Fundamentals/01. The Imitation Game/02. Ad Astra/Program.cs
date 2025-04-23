using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Regex pattern = new Regex(@"(\||#)([A-Z][A-Za-z ]+)\1([0-9]{2}\/[0-9]{2}\/[0-9]{2})\1([0-9]+)\1");

        string input = Console.ReadLine();

        MatchCollection matches = pattern.Matches(input);

        int days = GetDaysCount(matches);
        Console.WriteLine($"You have food to last you for: {days} days!");

        foreach (Match match in matches)
        {
            Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
        }
    }

    static int GetDaysCount(MatchCollection matches)
    {
        int calories = 0;

        foreach (Match match in matches)
        {
            calories += int.Parse(match.Groups[4].Value);
        }

        return calories / 2000;
    }
}