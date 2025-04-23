using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var n = int.Parse(Console.ReadLine());

        var queue = new Queue<string>(input);

        var currNumber = 1;

        while (1 < queue.Count)
        {
            if (currNumber == n)
            {
                Console.WriteLine($"Removed {queue.Dequeue()}");
                currNumber = 1;
                continue;
            }

            queue.Enqueue(queue.Dequeue());
            currNumber++;
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");

    }
}