using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var people = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            var currArgs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var name = currArgs[0];
            var age = int.Parse(currArgs[1]);

            if (!people.ContainsKey(name))
            {
                people[name] = 0;
            }

            people[name] = age;
        }

        var condition = Console.ReadLine();
        var conditionAge = int.Parse(Console.ReadLine());
        var format = Console.ReadLine();

        people = GetPeople(people, condition, conditionAge);


        if (format == "name age")
        {
            people.ToList().ForEach(x => Console.WriteLine(x.Key + " " + "-" + " " + x.Value));
        }
        else if (format == "name")
        {
            people.ToList().ForEach(x => Console.WriteLine(x.Key));
        }
        else if (format == "age")
        {
            people.ToList().ForEach(x => Console.WriteLine(x.Value));
        }

    }

    private static Dictionary<string, int> GetPeople(Dictionary<string, int> people, string? condition, int conditionAge)
    {

        if (condition == "older")
        {
            people = people
                .Where(p => p.Value >= conditionAge)
                .ToDictionary(p => p.Key, p => p.Value);
        }
        else
        {
            people = people
                .Where(p => p.Value < conditionAge)
                .ToDictionary(p => p.Key, p => p.Value);
        }

        return people;
    }
}