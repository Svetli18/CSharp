using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var stack = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            var ch = input[i];

            if (ch == '(')
            {
                stack.Push(i);
            }
            else if (ch == ')')
            {
                var startIndex = stack.Pop();
                var count = i - startIndex + 1;

                var str = input.Substring(startIndex, count);
                Console.WriteLine(str);

            }

        }

    }
}