using System;
using System.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        int[,] matrix = null;

        if(int.TryParse(Console.ReadLine(), out int n))
        {
            matrix = GetMatrix(n);
        }

        var firstDiagonal = 0; 
        var secondDiagonal = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            firstDiagonal += matrix[row, row];
            secondDiagonal += matrix[row, matrix.GetLength(0) - 1 - row];
        }

        Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));

    }

    static int[,] GetMatrix(int n)
    {
        var matrix = new int[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
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