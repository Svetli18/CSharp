using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        List<string> list = input
            .Split('|', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        list.Reverse();

        string str = "";

        for (int i = 0; i < list.Count; i++)
        {
            str += list[i] + " ";
        }

        List<string> result = str
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Console.WriteLine(string.Join(' ', result));
    }
}