using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<string, int> parser = n => int.Parse(n);
        Func<int, int, bool> predicate = (x, n) => x % n == 0;

        int count = parser(Console.ReadLine());

        int[] divisibleNumbs = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .ToArray();

        List<int> numbers = Enumerable.Range(1, count).ToList();
        HashSet<int> setDivs = new HashSet<int>();

        for (int i = 0; i < divisibleNumbs.Length; i++)
        {
            int current = divisibleNumbs[i];

            if(!setDivs.Contains(current))
            {
                setDivs.Add(current);
            }
        }

        foreach (var number in numbers)
        {
            bool isDiv = true;

            foreach (var divNumber in setDivs)
            {
                if (!predicate(number, divNumber))
                {
                    isDiv = false;
                    break;
                }
            }

            if (isDiv)
            {
                Console.Write(number + " ");
            }

        }

        Console.WriteLine();

    }
}