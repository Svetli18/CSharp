using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = command[0];

            if (command.Length == 3)
            {
                if (list.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                    continue;
                }

                list.Add(name);

            }
            else if (command.Length == 4)
            {
                if (!list.Contains(name))
                {
                    Console.WriteLine($"{name} is not in the list!");
                    continue;
                }

                list.Remove(name);

            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, list));

    }
}