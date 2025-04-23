using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var tryParse = int.TryParse(Console.ReadLine(), out int n);

        var dragons = new Dictionary<string, SortedDictionary<string, Dragon>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var type = input[0];
            var name = input[1];
            var tryParseDamage = double.TryParse(input[2], out double damage);
            var tryParseHealth = double.TryParse(input[3], out double health);
            var tryParseArmor = double.TryParse(input[4], out double armor);

            if (!tryParseDamage)
            {
                damage = 45;
            }
            if (!tryParseHealth)
            {
                health = 250;
            }
            if (!tryParseArmor)
            {
                armor = 10;
            }

            Dragon dragon = new Dragon(name, damage, health, armor);

            if (!dragons.ContainsKey(type))
            {
                dragons[type] = new SortedDictionary<string, Dragon>();
            }

            if (!dragons[type].ContainsKey(name))
            {
                dragons[type][name] = dragon;
            }
            else if (dragons[type].ContainsKey(name))
            {
                dragons[type][name].Damage = damage;
                dragons[type][name].Health = health;
                dragons[type][name].Armor = armor;
            }
        }

        foreach (var dvp in dragons)
        {
            var damage = dvp.Value.Sum(d => d.Value.Damage) / dvp.Value.Count;
            var health = dvp.Value.Sum(d => d.Value.Health) / dvp.Value.Count;
            var armor = dvp.Value.Sum(d => d.Value.Armor) / dvp.Value.Count;

            Console.WriteLine($"{dvp.Key}::({damage:F2}/{health:F2}/{armor:F2})");

            foreach (var nvp in dvp.Value)
            {
                Console.WriteLine($"-{nvp.Key} -> damage: {nvp.Value.Damage}, health: {nvp.Value.Health}, armor: {nvp.Value.Armor}");
            }
        }
    }
}

class Dragon
{
    public Dragon()
    {
        
    }

    public Dragon(string name, double damage, double health, double armor)
    {
        this.Name = name;
        this.Damage = damage;
        this.Health = health;
        this.Armor = armor;
    }

    public string Name { get; set; }
    public double Damage  { get; set; }
    public double Health  { get; set; }
    public double Armor  { get; set; }
}