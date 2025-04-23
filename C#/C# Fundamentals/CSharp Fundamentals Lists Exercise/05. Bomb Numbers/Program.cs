using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int[] bombInfo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int bomb = bombInfo[0];
        int power = bombInfo[1];

        while (list.Contains(bomb))
        {
            int index = list.IndexOf(bomb);

            BombDetonacionAndRightPower(list, power, index);

            if (0 <= index - 1)
            {
                LeftPower(list, power, index - 1);
            }

        }

        Console.WriteLine(list.Sum());

    }

    static void LeftPower(List<int> list, int power, int index)
    {
        for (int i = index; i >= 0; i--)
        {
            if (0 == power)
            {
                break;
            }

            list.RemoveAt(i);
            power--;

        }

    }

    static void BombDetonacionAndRightPower(List<int> list, int power, int index)
    {
        list.RemoveAt(index);

        while (index < list.Count && 0 < power)
        {
            list.RemoveAt(index);
            power--;

        }
        
    }
}