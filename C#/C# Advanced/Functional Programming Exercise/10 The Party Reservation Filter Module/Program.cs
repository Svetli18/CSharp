using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var predicates = new Dictionary<string, Predicate<string>>();

        string input = "";
        while ((input = Console.ReadLine()) != "Print")
        {
            string[] inputArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string filter = inputArgs[0];
            string type = inputArgs[1];
            string typeValue = inputArgs[2];


            if (filter == "Add filter")
            {
                if (!predicates.ContainsKey(type + " " + typeValue))
                {
                    predicates[type + " " + typeValue] = GetPredicate(type + ';' + typeValue);
                }
            }
            else if (filter == "Remove filter")
            {
                predicates.Remove(type + " " + typeValue);
            }

        }

        foreach (var kvp in predicates)
        {
            var current = kvp.Value;

            list = list.Where(n => !current(n)).ToList();
        }

        Console.WriteLine(string.Join(' ', list));
        
    }

    static Predicate<string> GetPredicate(string v)
    {
        string[] typeArgs = v.Split(';', StringSplitOptions.RemoveEmptyEntries);

        string type = typeArgs[0];
        string typeValue = typeArgs[1];

        if (type == "Starts with")
        {
            return x => x.StartsWith(typeValue);
        }
        else if (type == "Ends with")
        {
            return x => x.EndsWith(typeValue);
        }
        else if (type == "Contains")
        {
            return x => x.Contains(typeValue);
        }
        else if (type == "Length")
        {
            return x => x.Length == int.Parse(typeValue);
        }

        return null;

    }
}