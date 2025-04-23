using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var stack = new Stack<char>();

        var isBalance = true;

        foreach (var ch in input)
        {
            if (ch == '{' || ch == '[' || ch == '(')
            {
                stack.Push(ch);
            }
            else if (stack.Any() && stack.Peek() == '{' && ch == '}' ||
                stack.Any() && stack.Peek() == '[' && ch == ']' ||
                stack.Any() && stack.Peek() == '(' && ch == ')')
            {
                stack.Pop();
            }
            else
            {
                isBalance = false;
            }

        }

        if (isBalance)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }

    }
}