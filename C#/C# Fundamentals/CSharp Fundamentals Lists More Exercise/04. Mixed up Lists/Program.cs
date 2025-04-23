using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> first = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        List<int> second = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> numbers = GetNumbers(first, second);

        List<int> result = GetResult(first, second, numbers);

        result.Sort();

        Console.WriteLine(string.Join(" ", result));

    }

    static List<int> GetNumbers(List<int> first, List<int> second)
    {
        List<int> numbers = new List<int>();

        int length = Math.Min(first.Count, second.Count);

        for (int i = 0; i < length; i++)
        {
            numbers.Add(first[i]);
            numbers.Add(second[second.Count - 1 - i]);
        }

        return numbers;

    }

    static List<int> GetResult(List<int> first, List<int> second, List<int> numbers)
    {
        List<int> result = new List<int>();

        if (first.Count < second.Count)
        {
            int smallest = Math.Min(second[0], second[1]);
            int biggest = Math.Max(second[0], second[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (smallest < numbers[i] && numbers[i] < biggest)
                {
                    result.Add(numbers[i]);
                }
            }

        }
        else
        {
            int smallest = Math.Min(first[first.Count - 2], first[first.Count - 1]);
            int biggest = Math.Max(first[first.Count - 2], first[first.Count - 1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (smallest < numbers[i] && numbers[i] < biggest)
                {
                    result.Add(numbers[i]);
                }
            }
        }

        return result;
    }
}