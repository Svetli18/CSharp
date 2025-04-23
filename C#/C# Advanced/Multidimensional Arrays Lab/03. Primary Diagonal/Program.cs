using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var matrix = GetMatrix(n, n);

        var sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            sum += matrix[row, row];
        }

        Console.WriteLine(sum);

    }

    static int[,] GetMatrix(int n1, int n2)
    {
        var matrix = new int[n1, n2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine()
                .Split(new[] {' '})
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currRow[col];
            }

        }

        return matrix;
    }
}