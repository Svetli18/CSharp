using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var quantityFood = int.Parse(Console.ReadLine());

        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var orders = new Queue<int>(input);

        Console.WriteLine(orders.Max());

        while(orders.Any() && orders.Peek() <= quantityFood)
        {
            var currentOrder = orders.Dequeue();

            quantityFood -= currentOrder;

        }

        if (orders.Any())
        {
            Console.Write("Orders left: ");
            Console.WriteLine(string.Join(" ", orders));
        }
        else
        {
            Console.WriteLine("Orders complete");
        }

    }
}