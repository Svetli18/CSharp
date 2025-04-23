using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Regex pettern = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

        MatchCollection matchCollection = pettern.Matches(text);

        Console.WriteLine(string.Join(" ", matchCollection));
    }
}