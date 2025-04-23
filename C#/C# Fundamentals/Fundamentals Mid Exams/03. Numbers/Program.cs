using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        List<int> result = new List<int>();

        float averige = (float)array.Sum() / array.Length;

        for (int j = 0; j < 5; j++)
        {
            int biggestNumber = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                if (biggestNumber < currentNumber)
                {
                    biggestNumber = currentNumber;
                    index = i;
                }

            }

            if (-1 < index)
            {
                array[index] = int.MinValue;
            }

            if (averige < biggestNumber)
            {
                result.Add(biggestNumber);
            }

            if (result.Count == 5)
            {
                break;
            }
        }

        if (result.Count == 0)
        {
            Console.WriteLine("No");
        }

        result.OrderByDescending(e => e)
            .ToList();

        Console.WriteLine(string.Join(" ", result));
    }
}