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

        string input;
        while ((input = Console.ReadLine()) != "Party!")
        {
            string[] inputAtgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = inputAtgs[0];
            string type = inputAtgs[1];
            string typeValue = inputAtgs[2];

            if (command == "Double")
            {
                DoubleUpdateList(list, type, typeValue);
            }
            else if (command == "Remove")
            {
                RemoveUpdateList(list, type, typeValue);
            }

        }

        if (list.Any())
        {
            Console.Write(string.Join(", ", list));
            Console.WriteLine(" are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }

    }

    static void RemoveUpdateList(List<string> list, string type, string typeValue)
    {
        if (type == "StartsWith")
        {
            list.RemoveAll(n => n.StartsWith(typeValue));
        }
        else if (type == "EndsWith")
        {
            list.RemoveAll(n => n.EndsWith(typeValue));
        }
        else if (type == "Length")
        {
            var length = int.Parse(typeValue);

            list.RemoveAll(n => n.Length == length);
        }
    }

    static void DoubleUpdateList(List<string> list, string type, string typeValue)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string currentName = list[i];

            if (type == "StartsWith")
            {
                if (currentName.StartsWith(typeValue))
                {
                    list.Insert(i + 1, currentName);
                    i++;
                }
            }
            else if (type == "EndsWith")
            {
                if (currentName.EndsWith(typeValue))
                {
                    list.Insert(i + 1, currentName);
                    i++;
                }
            }
            else if (type == "Length")
            {
                var length = int.Parse(typeValue);
                if (currentName.Length == length)
                {
                    list.Insert(i + 1, currentName);
                    i++;
                }
            }
        }
    }
}