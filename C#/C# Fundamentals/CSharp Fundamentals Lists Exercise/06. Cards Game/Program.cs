using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> first = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> second = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        while (0 < first.Count && 0 < second.Count)
        {
            int firstHand = first[0];
            int secondHand = second[0];

            if (secondHand < firstHand)
            {
                first.RemoveAt(0);
                second.RemoveAt(0);

                first.Add(secondHand);
                first.Add(firstHand);
            }
            else if (firstHand < secondHand)
            {
                first.RemoveAt(0);
                second.RemoveAt(0);

                second.Add(firstHand);
                second.Add(secondHand);
            }
            else
            {
                first.RemoveAt(0);
                second.RemoveAt(0);
            }

        }

        if (0 < first.Count)
        {
            Console.WriteLine($"First player wins! Sum: {first.Sum()}");
        }
        else if (0 < second.Count)
        {
            Console.WriteLine($"Second player wins! Sum: {second.Sum()}");
        }

    }
}