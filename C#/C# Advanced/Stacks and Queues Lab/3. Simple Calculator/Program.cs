using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var stack = new Stack<string>(input.Reverse());

        while (2 < stack.Count)
        {
            var isParseNumber1 = int.TryParse(stack.Pop(), out var number1);
            var operatin = stack.Pop();
            var isParseNumber2 = int.TryParse(stack.Pop(), out var number2);

            switch (operatin)
            {
                case "+": stack.Push((number1 + number2).ToString()); 
                    break;
                case "-": stack.Push((number1 - number2).ToString());
                    break;
            }
        }

        Console.WriteLine(stack.Pop());
    }
}