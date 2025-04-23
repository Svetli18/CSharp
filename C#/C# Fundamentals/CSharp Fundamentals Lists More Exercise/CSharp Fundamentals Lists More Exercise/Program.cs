using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
       List<int> ints = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string text = Console.ReadLine();

        string result = string.Empty;

        while (0 < ints.Count)
        {
            int currNumber = ints[0];
            ints.RemoveAt(0);
            int index = 0;

            while (0 < currNumber)
            {
                index += currNumber % 10;
                currNumber /= 10;
            }

            while (text.Length <= index)
            {
                index -= text.Length;
            }

            result += text[index];
            text = text.Remove(index, 1);

        }

        Console.WriteLine(result);

    }
}