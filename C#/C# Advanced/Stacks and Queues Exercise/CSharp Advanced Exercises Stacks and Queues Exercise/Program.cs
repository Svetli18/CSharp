using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var cmd = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var numbs = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var stack = new Stack<int>(numbs);

        int smallestNumber = int.MaxValue;


        var elementsToRemove = cmd[1];
        var smecialElement = cmd[2];

        for (int i = 0; i < elementsToRemove && stack.Any(); i++)
        {
            stack.Pop();
        }

        if (!stack.Any())
        {
            Console.WriteLine(0);
        }
        else if (stack.Contains(smecialElement))
        {
            Console.WriteLine("true");
        }
        else if (!stack.Contains(smallestNumber))
        {
            Console.WriteLine(stack.Min());
        }
    }
}