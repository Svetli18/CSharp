using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var passedCarsCount = 0;

        var cars = new Queue<string>();

        var command = "";
        while((command = Console.ReadLine()) != "end")
        {
            if (command == "green")
            {
                for (int i = 0; i < n && cars.Any(); i++)
                {
                    Console.WriteLine($"{cars.Dequeue()} passed!");
                    passedCarsCount++;
                }
                continue;
            }

            cars.Enqueue(command);

        }

        Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");

    }
}