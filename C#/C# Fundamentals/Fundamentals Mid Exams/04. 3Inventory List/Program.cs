using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var inventory = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string cmd;
        while ((cmd = Console.ReadLine()) != "Craft!")
        {
            var cmdArgs = cmd.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];
            string item = cmdArgs[1];

            if (command == "Collect")
            {
                if (!inventory.Contains(item))
                {
                    inventory.Add(item);
                }

            }
            else if (command == "Drop")
            {
                inventory.Remove(item);
            }
            else if (command == "Combine Items")
            {
                var items = item.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string oldItem = items[0];
                string newItem = items[1];

                if (inventory.Contains(oldItem))
                {
                    int oldItemIdx = inventory.IndexOf(oldItem);
                    inventory.Insert(oldItemIdx + 1, newItem);
                }
            }
            else if (command == "Renew")
            {
                if (inventory.Contains(item))
                {
                    inventory.Remove(item);
                    inventory.Add(item);
                }
            }
        }

        Console.WriteLine(string.Join(", ", inventory));

    }
}