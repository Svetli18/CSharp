using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int element = 0;

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandArgsArray = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            element = int.Parse(commandArgsArray[1]);

            if (commandArgsArray.Length == 2)
            {
                int removeEl = int.Parse(commandArgsArray[1]);

                list = list.Where(e => e != removeEl).ToList();
            }
            else if (commandArgsArray.Length == 3)
            {
                int index = int.Parse(commandArgsArray[2]);

                list.Insert(index, element);
            }

        }

        Console.WriteLine(string.Join(' ', list));

    }
}