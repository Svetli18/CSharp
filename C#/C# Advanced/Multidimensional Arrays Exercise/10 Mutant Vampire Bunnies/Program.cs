using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var rowsAndCols = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = rowsAndCols[0];
        var c = rowsAndCols[1];

        var matrix = new char[r, c];

        var pRow = 0;
        var pCol = 0;
        var pWinGame = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currRow[col];

                if (currRow[col] == 'P')
                {
                    pRow = row;
                    pCol = col;
                }
            }
        }

        var directions = Console.ReadLine();

        for (int i = 0; i < directions.Length; i++)
        {
            //left
            if (directions[i] == 'L')
            {
                if (IsInside(matrix, pRow, pCol - 1))
                {
                    matrix[pRow, pCol] = '.';
                    pCol--;
                    if (matrix[pRow, pCol] == 'B')
                    {
                        AddVampireBunnies(matrix);
                        break;
                    }
                    matrix[pRow, pCol] = 'P';

                }
                else
                {
                    matrix[pRow, pCol] = '.';
                    pWinGame = true;
                    AddVampireBunnies(matrix);
                    break;
                }
            }
            //up
            if (directions[i] == 'U')
            {
                if (IsInside(matrix, pRow - 1, pCol))
                {
                    matrix[pRow, pCol] = '.';
                    pRow--;
                    if (matrix[pRow, pCol] == 'B')
                    {
                        AddVampireBunnies(matrix);
                        break;
                    }
                    matrix[pRow, pCol] = 'P';
                }
                else
                {
                    matrix[pRow, pCol] = '.';
                    pWinGame = true;
                    AddVampireBunnies(matrix);
                    break;
                }
            }
            //right
            if (directions[i] == 'R')
            {
                if (IsInside(matrix, pRow, pCol + 1))
                {
                    matrix[pRow, pCol] = '.';
                    pCol++;
                    if (matrix[pRow, pCol] == 'B')
                    {
                        AddVampireBunnies(matrix);
                        break;
                    }
                    matrix[pRow, pCol] = 'P';
                }
                else
                {
                    matrix[pRow, pCol] = '.';
                    pWinGame = true;
                    AddVampireBunnies(matrix);
                    break;
                }
            }
            //down
            if (directions[i] == 'D')
            {
                if (IsInside(matrix, pRow + 1, pCol))
                {
                    matrix[pRow, pCol] = '.';
                    pRow++;
                    if (matrix[pRow, pCol] == 'B')
                    {
                        AddVampireBunnies(matrix);
                        break;
                    }
                    matrix[pRow, pCol] = 'P';
                }
                else
                {
                    matrix[pRow, pCol] = '.';
                    pWinGame = true;
                    AddVampireBunnies(matrix);
                    break;
                }
            }

            AddVampireBunnies(matrix);

            if (IsBunniesKillPlayer(matrix))
            {
                break;
            }

        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]}");
            }
            Console.WriteLine();
        }

        if (pWinGame)
        {
            Console.WriteLine($"won: {pRow} {pCol}");
        }
        else
        {
            Console.WriteLine($"dead: {pRow} {pCol}");
        }

    }

    static bool IsBunniesKillPlayer(char[,] matrix)
    {
        var playerDies = true;

        foreach (char ch in matrix)
        {
            if (ch == 'P')
            {
                playerDies = false;
            }
        }

        return playerDies;
    }

    static void AddVampireBunnies(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    //left
                    if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] != 'B')
                    {
                        matrix[row, col - 1] = 'b';
                    }
                    //up
                    if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] != 'B')
                    {
                        matrix[row - 1, col] = 'b';
                    }
                    //right
                    if (IsInside(matrix, row, col + 1) && matrix[row, col + 1] != 'B')
                    {
                        matrix[row, col + 1] = 'b';
                    }
                    //down
                    if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] != 'B')
                    {
                        matrix[row + 1, col] = 'b';
                    }
                }
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'b')
                {
                    matrix[row, col] = 'B';
                }
            }
        }
    }

    static bool IsInside(char[,] matrix, int pRow, int pCol)
    {
        var isInside = false;

        if (0 <= pRow && pRow < matrix.GetLength(0) &&
            0 <= pCol && pCol < matrix.GetLength(1))
        {
            isInside = true;
        }

        return isInside;
    }
}