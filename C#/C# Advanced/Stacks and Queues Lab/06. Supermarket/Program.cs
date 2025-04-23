using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var costomers = new Queue<string>();

        var command = "";
        while ((command = Console.ReadLine()) != "End")
        {
            if (command == "Paid")
            {
                while(costomers.Any())
                {
                    Console.WriteLine(costomers.Dequeue());
                }
                continue;
            }

            costomers.Enqueue(command);

        }

        Console.WriteLine($"{costomers.Count} people remaining.");

    }
}