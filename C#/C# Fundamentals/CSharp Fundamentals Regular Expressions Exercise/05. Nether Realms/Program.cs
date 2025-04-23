using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] array = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        SortedDictionary<string, Demon> demons = new SortedDictionary<string, Demon>();

        Regex namePattern = new Regex(@"([^0-9+\-\/*\.])");
        Regex calculatePattern = new Regex(@"((-?\.?[0-9])+|[*\/])");

        for (int i = 0; i < array.Length; i++)
        {
            int health = 0;
            MatchCollection match = namePattern.Matches(array[i]);
            MatchCollection matchCalculateSimbols = calculatePattern.Matches(array[i]);
            string name = string.Concat(match);
            double damage = 0;

            if (match != null)
            {
                health = GetNameSum(name);
            }

            if (matchCalculateSimbols != null)
            {
                damage = GetDamageFromCalculation(matchCalculateSimbols);
            }

            if (!demons.ContainsKey(array[i]))
            {
                demons[array[i]] = new Demon(health, damage);
            }
            else
            {
                demons[array[i]].Health = health;
                demons[array[i]].Damage = damage;
            }

        }

        if (demons.Any())
        {
            demons.ToList()
            .ForEach(d => Console.WriteLine($"{d.Key} - {d.Value.Health} health, {d.Value.Damage:F2} damage"));
        }

    }

    private static double GetDamageFromCalculation(MatchCollection matchDigits)
    {
        double damage = 0;

        foreach (Match item in matchDigits)
        {
            if (item.Value == "*")
            {
                damage *= 2;
            }
            else if (item.Value == "/")
            {
                damage /= 2;
            }
            else
            {
                damage += double.Parse(item.Value);
            }
        }

        return damage;
    }

    private static int GetNameSum(string name)
    {
        int sum = 0;

        for (int i = 0; i < name.Length; i++)
        {
            sum += name[i];
        }

        return sum;
    }
}

public class Demon
{
    public Demon(int health, double damage)
    {
        Health = health;
        Damage = damage;
    }
    public int Health { get; set; }
    public double Damage { get; set; }
}