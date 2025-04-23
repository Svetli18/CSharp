using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int result = 0;

        while (0 < list.Count)
        {
            int index = int.Parse(Console.ReadLine());

            if (index < 0)
            {
                int firstElement = list[0];
                result += list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] += firstElement;
                }
                continue;

            }
            else if (list.Count - 1 < index)
            {
                int lastElement = list[list.Count - 1];
                result += lastElement;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] += lastElement;
                }
                continue;

            }

            result = GerResult(list, result, index);

        }

        Console.WriteLine(result);

    }

    private static int GerResult(List<int> list, int result, int index)
    {
        int currentElement = list[index];
        list.RemoveAt(index);
        result += currentElement;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] <= currentElement)
            {
                list[i] += currentElement;
                continue;
            }

            list[i] -= currentElement;

        }

        return result;
    }
}