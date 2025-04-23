using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var dimensions = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string[,] matrix = null;

        var rBool = int.TryParse(dimensions[0], out int r);
        var cBool = int.TryParse(dimensions[1], out int c);

        if (rBool && cBool)
        {
            matrix = GetMatrix(r, c);
        }

        var cnt = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                var currElement = matrix[row, col];

                if (currElement.Equals(matrix[row, col + 1]) &&
                    currElement.Equals(matrix[row + 1, col]) &&
                    currElement.Equals(matrix[row + 1, col + 1]))
                {
                    cnt++;
                }
            }
        }

        Console.WriteLine(cnt);

    }

    static string[,] GetMatrix(int r, int c)
    {
        var matrix = new string[r, c];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        return matrix;
    }
}