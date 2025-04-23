using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());


        var commands = Console.ReadLine().ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var matrix = new char[n, n];
        var mRow = 0;
        var mCol = 0;
        int totalCoals = 0;
        int coalsCount = 0;
        var isGameOver = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col];

                if (currentRow[col] == 'c')
                {
                    totalCoals++;
                }
                else if (currentRow[col] == 's')
                {
                    mRow = row;
                    mCol = col;
                }
            }
        }

        for (int i = 0; i < commands.Length; i++)
        {
            //Left
            if (commands[i] == "left" && IsInside(matrix, mRow, mCol - 1))
            {
                if (matrix[mRow, mCol - 1] == 'e')
                {
                    matrix[mRow, mCol] = '*';
                    mCol--;
                    Console.WriteLine($"Game over! ({mRow}, {mCol})");
                    isGameOver = true;
                    break;
                }
                else if (matrix[mRow, mCol - 1] == 'c')
                {
                    matrix[mRow, mCol] = '*';
                    mCol--;
                    matrix[mRow, mCol] = 's';
                    coalsCount++;
                    if (coalsCount == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({mRow}, {mCol})");
                        break;
                    }
                    continue;
                }

                matrix[mRow, mCol] = '*';
                mCol--;
                matrix[mRow, mCol] = 's';

            }
            //Up
            else if (commands[i] == "up" && IsInside(matrix, mRow - 1, mCol))
            {
                if (matrix[mRow - 1, mCol] == 'e')
                {
                    matrix[mRow, mCol] = '*';
                    mRow--;
                    Console.WriteLine($"Game over! ({mRow}, {mCol})");
                    isGameOver = true;
                    break;
                }
                else if (matrix[mRow - 1, mCol] == 'c')
                {
                    matrix[mRow, mCol] = '*';
                    mRow--;
                    matrix[mRow, mCol] = 's';
                    coalsCount++;
                    if (coalsCount == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({mRow}, {mCol})");
                        break;
                    }
                    continue;
                }

                matrix[mRow, mCol] = '*';
                mRow--;
                matrix[mRow, mCol] = 's';

            }
            //Right
            else if (commands[i] == "right" && IsInside(matrix, mRow, mCol + 1))
            {
                if (matrix[mRow, mCol + 1] == 'e')
                {
                    matrix[mRow, mCol] = '*';
                    mCol++;
                    Console.WriteLine($"Game over! ({mRow}, {mCol})");
                    isGameOver = true;
                    break;
                }
                else if (matrix[mRow, mCol + 1] == 'c')
                {
                    matrix[mRow, mCol] = '*';
                    mCol++;
                    matrix[mRow, mCol] = 's';
                    coalsCount++;
                    if (coalsCount == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({mRow}, {mCol})");
                        break;
                    }
                    continue;
                }

                matrix[mRow, mCol] = '*';
                mCol++;
                matrix[mRow, mCol] = 's';

            }
            //Down
            else if (commands[i] == "down" && IsInside(matrix, mRow + 1, mCol))
            {
                if (matrix[mRow + 1, mCol] == 'e')
                {
                    matrix[mRow, mCol] = '*';
                    mRow++;
                    Console.WriteLine($"Game over! ({mRow}, {mCol})");
                    isGameOver = true;
                    break;
                }
                else if (matrix[mRow + 1, mCol] == 'c')
                {
                    matrix[mRow, mCol] = '*';
                    mRow++;
                    matrix[mRow, mCol] = 's';
                    coalsCount++;
                    if (coalsCount == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({mRow}, {mCol})");
                        break;
                    }
                    continue;
                }

                matrix[mRow, mCol] = '*';
                mRow++;
                matrix[mRow, mCol] = 's';

            }
        }

        if (coalsCount < totalCoals && !isGameOver)
        {
            Console.WriteLine($"{totalCoals - coalsCount} coals left. ({mRow}, {mCol})");
        }

    }

    static bool IsInside(char[,] matrix, int minerRow, int minerCol)
    {
        var isInside = false;

        if (0 <= minerRow && minerRow < matrix.GetLength(0) && 
            0 <= minerCol && minerCol < matrix.GetLength(1))
        {
            isInside = true;
        }

        return isInside;

    }
}