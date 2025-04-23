using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int firstX1 = int.Parse(Console.ReadLine());
        int firstY1 = int.Parse(Console.ReadLine());
        int firstX2 = int.Parse(Console.ReadLine());
        int firstY2 = int.Parse(Console.ReadLine());
        int secondX1 = int.Parse(Console.ReadLine());
        int secondY1 = int.Parse(Console.ReadLine());
        int secondX2 = int.Parse(Console.ReadLine());
        int secondY2 = int.Parse(Console.ReadLine());

        int[] result = GetResultFromCordinate(firstX1, firstY1, firstX2, firstY2,
            secondX1, secondY1, secondX2, secondY2);
        int[] firstResult = { result[0], result[1] };
        int[] secondResult = { result[2], result[3] };

        PrintResult(firstResult);
        PrintResult(secondResult);

        Console.WriteLine();

    }

    static void PrintResult(int[] result)
    {
        Console.Write("(");
        Console.Write(string.Join(", ", result));
        Console.Write(")");
    }

    static int[] GetResultFromCordinate(int firstX1, int firstY1, int firstX2, int firstY2, int secondX1, int secondY1, int secondX2, int secondY2)
    {
        int[] result = new int[4];

        if (Math.Abs(firstX1 + firstY1 + firstX2 + firstY2) <= Math.Abs(secondX1 + secondY1 + secondX2 + secondY2))
        {
            result[0] = secondX2;
            result[1] = secondY2;
            result[2] = secondX1;
            result[3] = secondY1;
            return result;
        }
        else
        {
            result[0] = firstX2;
            result[1] = firstY2;
            result[2] = firstX1;
            result[3] = firstY1;
            return result;
        }
    }
}