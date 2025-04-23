using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.None);

        List<string> userNames = new List<string>();

        foreach (string name in input)
        {
            bool IsUser = true;

            if (name.Length < 3 || 16 < name.Length)
            {
                continue;
            }

            foreach (var ch in name)
            {
                if (ch == '-' || ch == '_')
                {
                    continue;
                }
                else if (!char.IsLetterOrDigit(ch))
                {
                    IsUser = false;
                    break;
                }
                
            }

            if (IsUser)
            {
                userNames.Add(name);
            }
        }

        userNames.ForEach(x => Console.WriteLine(x));

    }
}