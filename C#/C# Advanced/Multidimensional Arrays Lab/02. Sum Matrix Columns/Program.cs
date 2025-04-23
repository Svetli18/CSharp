using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var rows = input[0];
        var cols = input[1];

        var matrix = GetMatrix(rows, cols);

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            var colSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                colSum += matrix[row, col];
            }

            Console.WriteLine(colSum);

        }
    }

    static int[,] GetMatrix(int rows, int cols)
    {
        var matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currentRow = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        return matrix;
    }
}