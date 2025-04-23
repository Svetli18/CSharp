using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var heroes = GetHeroes(n);

        var cmd = "";
        while ((cmd = Console.ReadLine()) != "End")
        {
            var cmdArgs = cmd.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var command = cmdArgs[0];
            var heroName = cmdArgs[1];

            if (command == "CastSpell" && heroes.ContainsKey(heroName))
            {
                var mp = int.Parse(cmdArgs[2]);
                var spellName = cmdArgs[3];

                if (mp <= heroes[heroName].MP)
                {
                    heroes[heroName].MP -= mp;
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                    continue;
                }

                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");

            }
            else if (command == "TakeDamage" && heroes.ContainsKey(heroName))
            {
                var damage = int.Parse(cmdArgs[2]);
                var attacker = cmdArgs[3];

                if (0 < heroes[heroName].HP - damage)
                {
                    heroes[heroName].HP -= damage;
                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    continue;
                }

                heroes.Remove(heroName);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");

            }
            else if (command == "Recharge" && heroes.ContainsKey(heroName))
            {
                var rechargeMP = int.Parse(cmdArgs[2]);

                if (200 < heroes[heroName].MP + rechargeMP)
                {
                    Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName].MP} MP!");
                    heroes[heroName].MP = 200;
                    continue;
                }

                heroes[heroName].MP += rechargeMP;
                Console.WriteLine($"{heroName} recharged for {rechargeMP} MP!");

            }
            else if (command == "Heal" && heroes.ContainsKey(heroName))
            {
                var recoveredHP = int.Parse(cmdArgs[2]);

                if (100 < heroes[heroName].HP + recoveredHP)
                {
                    Console.WriteLine($"{heroName} healed for {100 - heroes[heroName].HP} HP!");
                    heroes[heroName].HP = 100;
                    continue;
                }

                heroes[heroName].HP += recoveredHP;
                Console.WriteLine($"{heroName} healed for {recoveredHP} HP!");

            }
        }

        if (0 < heroes.Count)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }

    }

    static Dictionary<string, Hero> GetHeroes(int n)
    {
        var heroes = new Dictionary<string, Hero>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var name = input[0];
            var hp = int.Parse(input[1]);
            var mp = int.Parse(input[2]);

            var hero = new Hero(hp, mp);

            heroes[name] = hero;
        }

        return heroes;
    }
}

class Hero
{
    public Hero(int hp, int mp)
    {
        HP = hp;
        MP = mp;
    }

    public int HP { get; set; }
    public int MP { get; set; }
}