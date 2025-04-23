using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputCups = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var inputBottles = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var cups = new Queue<int>(inputCups);

        var bottles = new Stack<int>(inputBottles);

        var wastedLater = 0;

        while (cups.Any() && bottles.Any())
        {
            var currCup = cups.Peek();

            while (0 < currCup)
            {
                var currBottle = bottles.Pop();

                currCup -= currBottle;

                if (currCup <= 0)
                {
                    cups.Dequeue();
                    wastedLater += Math.Abs(currCup);
                }
            }

        }

        if (bottles.Any() && !cups.Any())
        {
            Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLater}");
        }
        if (cups.Any() && !bottles.Any())
        {
            Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedLater}");
        }

    }
}