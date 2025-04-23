using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var commands = new Stack<string>();

        var text = "";

        for (int i = 0; i < n; i++)
        {
            var current = Console.ReadLine().Split();

            if (current[0] == "1")
            {
                text += current[1];
                commands.Push(current[1].Length.ToString());
            }
            else if (current[0] == "2")
            {
                var isValid = int.TryParse(current[1], out int x);
                if (isValid)
                {
                    commands.Push(text.Substring(text.Length - x, x));
                    text = text.Remove(text.Length - x, x);
                }

            }
            else if (current[0] == "3")
            {
                var isValid = int.TryParse(current[1], out int idx);
                if (isValid)
                {
                    Console.WriteLine(text[idx - 1]);
                }
            }
            else if (current[0] == "4")
            {
                if (commands.Any())
                {
                    var curr = commands.Pop();

                    if (char.IsDigit(curr[0]))
                    {
                        var x = int.Parse(curr);
                        text = text.Remove(text.Length - x, x);
                    }
                    else
                    {
                        text += curr;
                    }
                }
            }
        }
    }
}