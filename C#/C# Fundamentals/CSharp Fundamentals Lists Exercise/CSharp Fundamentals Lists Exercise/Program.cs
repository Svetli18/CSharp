using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> train = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int maxCapacity = int.Parse(Console.ReadLine());

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (char.IsLetter(command[0]))
            {
                string[] commadArr = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int wagon = int.Parse(commadArr[1]);

                train.Add(wagon);

                continue;
            }

            int passengers = int.Parse(command);

            for (int i = 0; i < train.Count; i++)
            {
                if (train[i] + passengers <= maxCapacity)
                {
                    train[i] += passengers;
                    break;
                }

            }

        }

        Console.WriteLine(string.Join(' ', train));

    }
}