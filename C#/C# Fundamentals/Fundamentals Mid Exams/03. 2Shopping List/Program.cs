using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> store = Console.ReadLine()
            .Split('!', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string cmd;
        while ((cmd = Console.ReadLine()) != "Go Shopping!")
        {
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];
            string product = cmdArgs[1];

            if (command == "Urgent")
            {
                if (!store.Contains(product))
                {
                    store.Insert(0, product);
                }
            }
            else if (command == "Unnecessary")
            {
                store.Remove(product);
            }
            else if (command == "Correct")
            {
                if (store.Contains(product))
                {
                    string newProduct = cmdArgs[2];
                    int index = store.IndexOf(product);
                    store[index] = newProduct;
                }
            }
            else if (command == "Rearrange")
            {
                if (store.Contains(product))
                {
                    int index = store.IndexOf(product);
                    store.RemoveAt(index);
                    store.Add(product);
                }
            }
        }

        Console.WriteLine(string.Join(", ", store));

    }
}