using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var sum = 0;

        Regex pattern = new Regex(@"(=|\/)([A-Z][A-Za-z]{2,})\1");

        MatchCollection matches = pattern.Matches(input);


        if (0 < matches.Count)
        {

            Console.Write($"Destinations: ");

            for (int i = 0; i < matches.Count; i++)
            {
                if (0 < i)
                {
                    Console.Write($", {matches[i].Groups[2].Value}");
                }
                else
                {
                    Console.Write($"{matches[i].Groups[2].Value}");
                }

                sum += matches[i].Groups[2].Value.Length;
            }

            Console.WriteLine();

        }
        else
        {
            Console.WriteLine($"Destinations: ");
        }

        Console.WriteLine($"Travel Points: {sum}");

    }
}