using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] houses = Console.ReadLine()
            .Split('@', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int index = 0;

        string cmd;
        while ((cmd = Console.ReadLine()) != "Love!")
        {
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            if (command == "Jump")
            {
                int length = int.Parse(cmdArgs[1]);

                if (houses.Length - 1 < index + length)
                {
                    index = 0;
                    if (houses[index] == 0)
                    {
                        Console.WriteLine($"Place {index} already had Valentine's day.");
                    }
                    else
                    {
                        houses[index] -= 2;

                        if (houses[index] == 0)
                        {
                            Console.WriteLine($"Place {index} has Valentine's day.");
                        }

                    }
                    continue;

                }

                index += length;

                if (houses[index] == 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }
                else
                {
                    houses[index] -= 2;

                    if (houses[index] == 0)
                    {
                        Console.WriteLine($"Place {index} has Valentine's day.");
                    }

                }
            }
        }

        Console.WriteLine($"Cupid's last position was {index}.");

        houses = houses.Where(h => h > 0).ToArray();

        if (0 < houses.Length)
        {
            Console.WriteLine($"Cupid has failed {houses.Length} places.");
        }
        else
        {
            Console.WriteLine("Mission was successful.");
        }

    }
}