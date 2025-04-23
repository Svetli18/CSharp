using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        int numb = int.Parse(Console.ReadLine());
        char[] chars = new char[] { 's', 't', 'a', 'r' };
        Regex pattern = new
            Regex(@"@([A-Z][a-z]+)[^@!:-]*?:(\d+)[^@!:-]*?!(A|D)![^@!:-]*?->(\d+)");

        List<Match> matches = new List<Match>();
        List<Match> attackedPlanets = new List<Match>();
        List<Match> destroyedPlanets = new List<Match>();

        for (int i = 0; i < numb; i++)
        {
            string text = Console.ReadLine();
            int cnt = GetKeyForDecrypt(text, chars);
            string decrypted = DecriptedText(text, cnt);
            Match match = pattern.Match(decrypted);

            if (match.Success)
            {
                matches.Add(match);
            }
        }

        attackedPlanets = GetSortAttackedPlanets(matches);
        destroyedPlanets = GetSortDestroyedPlanets(matches);

        Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

        if (attackedPlanets.Any())
        {
            foreach (Match match in attackedPlanets)
            {
                Console.WriteLine($"-> {match.Groups[1]}");
            }
        }

        Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

        if (destroyedPlanets.Any())
        {
            foreach (Match match in destroyedPlanets)
            {
                Console.WriteLine($"-> {match.Groups[1]}");
            }
        }
    }

    static List<Match> GetSortAttackedPlanets(List<Match> matches)
    {
        List<Match> planets = new List<Match>();

        foreach (Match match in matches)
        {
            if (match.Groups[3].ToString() == "A")
            {
                planets.Add(match);
            }
        }

        return planets.OrderBy(x => x.Groups[1].Value).ToList();
    }

    static List<Match> GetSortDestroyedPlanets(List<Match> matches)
    {
        List<Match> planets = new List<Match>();

        foreach (Match match in matches)
        {
            if (match.Groups[3].ToString() == "D")
            {
                planets.Add(match);
            }
        }

        return planets.OrderBy(x => x.Groups[1].Value).ToList();
    }

    private static int GetKeyForDecrypt(string text, char[] chars)
    {
        int cnt = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (chars.Contains(char.ToLower(text[i])))
            {
                cnt++;
            }
        }

        return cnt;
    }

    private static string DecriptedText(string text, int cnt)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char decryptCh = (char)(text[i] - cnt);
            sb.Append(decryptCh);
        }

        return sb.ToString();
    }
}