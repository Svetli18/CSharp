using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = input[0];
        var c = input[1];

        var matrix = GetMatrix(r, c);

        var bestRow = 0;
        var bestCol = 0;
        var bestSum = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                var currSum = matrix[row, col] + 
                    matrix[row, col + 1] +
                    matrix[row + 1, col] +
                    matrix[row + 1, col + 1];

                if (bestSum < currSum)
                {
                    bestRow = row;
                    bestCol = col;
                    bestSum = currSum;
                }
            }
        }

        for (int row = bestRow; row <= bestRow + 1; row++)
        {
            for (int col = bestCol; col <= bestCol + 1; col++)
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

        Console.WriteLine(bestSum);

    }

    static int[,] GetMatrix(int r, int c)
    {
        var matrix = new int[r, c];

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currRow[col];
            }
        }

        return matrix;
    }
}