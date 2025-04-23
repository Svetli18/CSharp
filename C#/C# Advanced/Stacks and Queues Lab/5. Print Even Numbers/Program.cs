using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var numbs = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var queue = new Queue<int>();

        for (int i = 0; i < numbs.Length; i++)
        {
            if (numbs[i] % 2 == 0) 
            {
                queue.Enqueue(numbs[i]); 
            }
        }

        Console.WriteLine(string.Join(", ", queue));

    }
}