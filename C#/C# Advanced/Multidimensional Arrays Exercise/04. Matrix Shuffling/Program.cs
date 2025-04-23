using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[,] matrix = null;

        if (int.TryParse(input[0], out int r) && int.TryParse(input[1], out int c))
        {
            matrix = GetMatrix(r, c);
        }


        var command = "";
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var currCommand = commandArgs[0];

            if (currCommand == "swap")
            {
                var row1Bool = int.TryParse(commandArgs[1], out int row1);
                var col1Bool = int.TryParse(commandArgs[2], out int col1);
                var row2Bool = int.TryParse(commandArgs[3], out int row2);
                var col2Bool = int.TryParse(commandArgs[4], out int col2);

                if (row1Bool && col1Bool && row2Bool && col2Bool)
                {
                    if (0 <= row1 && row1 < matrix.GetLength(0) &&
                    0 <= col1 && col1 < matrix.GetLength(1) &&
                    0 <= row2 && row2 < matrix.GetLength(0) &&
                    0 <= col2 && col2 < matrix.GetLength(1))
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        PrintMatrix(matrix);
                        continue;
                    }
                }
            }
            Console.WriteLine("Invalid input!");

        }


    }

    static void PrintMatrix(string[,] matrix)
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

    static string[,] GetMatrix(int r, int c)
    {
        var matrix = new string[r, c];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        return matrix;
    }
}