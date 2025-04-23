using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var matrix = GetMatrix(n);

        var bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var AliveCellsCounter = 0;
        var AliveCellsSum = 0;

        for (int i = 0; i < bombs.Length; i++)
        {
            var currBomb = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
            var rowBool = int.TryParse(currBomb[0], out int row);
            var colBool = int.TryParse(currBomb[1], out int col);

            if (rowBool && colBool && 0 < matrix[row, col])
            {
                //UpLeft
                if (IsInside(matrix, row - 1, col - 1) && 0 < matrix[row - 1, col - 1])
                {
                    matrix[row - 1, col - 1] -= matrix[row, col];
                }
                //Up
                if (IsInside(matrix, row - 1, col) && 0 < matrix[row - 1, col])
                {
                    matrix[row - 1, col] -= matrix[row, col];
                }
                //UpRight
                if (IsInside(matrix, row - 1, col + 1) && 0 < matrix[row - 1, col + 1])
                {
                    matrix[row - 1, col + 1] -= matrix[row, col];
                }
                //Left
                if (IsInside(matrix, row, col - 1) && 0 < matrix[row, col - 1])
                {
                    matrix[row, col - 1] -= matrix[row, col];
                }
                //Right
                if (IsInside(matrix, row, col + 1) && 0 < matrix[row, col + 1])
                {
                    matrix[row, col + 1] -= matrix[row, col];
                }
                //DownLeft
                if (IsInside(matrix, row + 1, col - 1) && 0 < matrix[row + 1, col - 1])
                {
                    matrix[row + 1, col - 1] -= matrix[row, col];
                }
                //Down
                if (IsInside(matrix, row + 1, col) && 0 < matrix[row + 1, col])
                {
                    matrix[row + 1, col] -= matrix[row, col];
                }
                //DownRight
                if (IsInside(matrix, row + 1, col + 1) && 0 < matrix[row + 1, col + 1])
                {
                    matrix[row + 1, col + 1] -= matrix[row, col];
                }

                matrix[row, col] = 0;
            }

        }

        foreach (var element in matrix)
        {
            if (0 < element)
            {
                AliveCellsCounter++;
                AliveCellsSum += element;
            }
        }

        Console.WriteLine($"Alive cells: {AliveCellsCounter}");
        Console.WriteLine($"Sum: {AliveCellsSum}");

        PrintMatrix(matrix);

    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == 0)
                {
                    Console.Write($"{matrix[row, col]}");
                    continue;
                }

                Console.Write($" {matrix[row, col]}");
            }

            Console.WriteLine();
        }
    }

    static bool IsInside(int[,] matrix, int row, int col)
    {
        var isInside = false;

        if (0 <= row && row < matrix.GetLength(0) && 
            0 <= col && col < matrix.GetLength(1))
        {
            isInside = true;
        }

        return isInside;
    }

    static int[,] GetMatrix(int n)
    {
        var matrix = new int[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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