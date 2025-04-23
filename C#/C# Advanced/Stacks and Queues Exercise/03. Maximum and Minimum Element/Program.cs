using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            var curent = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var command = curent[0];

            if(command == "1" && int.TryParse(curent[1], out int element))
            {
                stack.Push(element);
            }
            else if(command == "2" && stack.Any())
            {
                stack.Pop();
            }
            else if (command == "3" && stack.Any())
            {
                Console.WriteLine(stack.Max());
            }
            else if (command == "4" && stack.Any())
            {
                Console.WriteLine(stack.Min());
            }

        }

        Console.WriteLine(string.Join(", ", stack));

    }
}