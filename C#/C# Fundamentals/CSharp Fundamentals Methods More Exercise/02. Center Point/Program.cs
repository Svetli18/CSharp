using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        int[] result = GetResultFromCordinate(x1, x2, y1, y2);

        Console.Write("(");
        Console.Write(string.Join(", ", result));
        Console.WriteLine(")");

    }

    static int[] GetResultFromCordinate(int x1, int x2, int y1, int y2)
    {
        int[] result = new int[2];

        int first = Math.Abs(x1 + y1);
        int second = Math.Abs(x2 + y2);

        if (first <= second)
        {
            result[0] = x1;
            result[1] = y1;
            return result;
        }

        result[0] = x2;
        result[1] = y2;
        return result;

    }
}