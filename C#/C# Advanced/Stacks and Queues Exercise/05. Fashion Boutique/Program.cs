using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int maxCapacity = int.Parse(Console.ReadLine());

        int cnt = 0;

        var stack = new Stack<int>(input);

        while (stack.Any())
        {
            var currentBox = maxCapacity;

            if (stack.Peek() <= currentBox)
            {
                cnt++;
            }

            while (stack.Any() && stack.Peek() <= currentBox)
            {
                var currentItem = stack.Pop();
                currentBox -= currentItem;

                if(currentBox == 0 || stack.Any() && currentBox < stack.Peek())
                {
                    break;
                }
            }
        }

        Console.WriteLine(cnt);

    }
}