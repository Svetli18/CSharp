using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> targets = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string cmd;
        while ((cmd = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];
            int index = int.Parse(cmdArgs[1]);

            

            if (command == "Shoot")
            {
                if (index < 0 || targets.Count - 1 < index)
                {
                    continue;
                }
                int power = int.Parse(cmdArgs[2]);

                targets[index] -= power;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
            else if (command == "Add")
            {
                if (index < 0 || targets.Count - 1 < index)
                {
                    Console.WriteLine("Invalid placement!");
                    continue;
                }

                int value  = int.Parse(cmdArgs[2]);

                targets.Insert(index, value);

            }
            else if (command == "Strike")
            {
                int radius = int.Parse(cmdArgs[2]);

                if (index < 0 || targets.Count - 1 < index || index - radius < 0 || targets.Count - 1 < index + radius)
                {
                    Console.WriteLine("Strike missed!");
                    continue;
                }

                targets.RemoveAt(index);

                for (int i = 0; i < radius; i++)
                {
                    targets.RemoveAt(index);
                }

                for (int i = 0; i < radius; i++)
                {
                    targets.RemoveAt(index - radius);
                }

            }

        }

        Console.WriteLine(string.Join('|', targets));

    }
}