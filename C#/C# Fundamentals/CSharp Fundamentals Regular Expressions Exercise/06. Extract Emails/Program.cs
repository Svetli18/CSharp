using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Regex pattern = new Regex
  (@"(^| )([A-Za-z0-9]+([_\-\.]*)?[A-Za-z0-9]*)@([a-z][a-z-]+\.([a-z]+)(\.?[a-z]+))");

        MatchCollection matches = pattern.Matches(text);

        if (matches != null)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }

    }
}