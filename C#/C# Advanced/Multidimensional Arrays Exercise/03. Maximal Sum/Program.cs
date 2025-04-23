using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = dimensions[0];
        var c = dimensions[1];

        var matrix = GetMatrix(r, c);

        var bestRow = 0;
        var bestCol = 0;
        var bestSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (bestSum < currentSum)
                {
                    bestSum = currentSum;
                    bestRow = row;
                    bestCol = col;
                }

            }

        }

        Console.WriteLine($"Sum = {bestSum}");
        PrintResultDimension(matrix, bestRow, bestCol);
    }

    static void PrintResultDimension(int[,] matrix, int bestRow, int bestCol)
    {
        for (int row = bestRow; row < bestRow + 3; row++)
        {
            for (int col = bestCol; col < bestCol + 3; col++)
            {
                if (col == bestCol)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                else
                {
                    Console.Write($" {matrix[row, col]}");
                }
            }
            Console.WriteLine();
        }
    }

    static int[,] GetMatrix(int r, int c)
    {
        var matrix = new int[r, c];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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