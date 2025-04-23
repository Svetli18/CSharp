using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Regex pattern = new Regex(@"(\+[0-9]{3}(-| )2\2[0-9]{3}\2[0-9]{4})\b");

        MatchCollection matches = pattern.Matches(text);

        if (matches != null)
        {
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}