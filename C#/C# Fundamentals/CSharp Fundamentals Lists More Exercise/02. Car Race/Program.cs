using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] race = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        float left = 0;
        float right = 0;

        for (int i = 0; i < race.Length / 2; i++)
        {
            float currentLeft = race[i];
            float currentRight = race[race.Length - 1 - i];

            if (currentLeft == 0)
            {
                left *= 0.8f;
            }
            if (currentRight == 0)
            {
                right *= 0.8f;
            }

            left += currentLeft;
            right += currentRight;
        }

        if (left < right)
        {
            Console.WriteLine($"The winner is left with total time: {left}");
        }
        else if (right < left)
        {
            Console.WriteLine($"The winner is right with total time: {right}");
        }

    }
}