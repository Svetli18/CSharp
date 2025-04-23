using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var matrix = ReadMatrix(n);

        var counter = 0;

        while (true)
        {
            var isHaveAttack = false;

            var removeKnightRow = 0;
            var removeKnightCol = 0;
            var bestCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '0')
                    {
                        continue;
                    }

                    var currCounter = IsHaveAttackTarget(matrix, row, col);

                    if(bestCount < currCounter)
                    {
                        bestCount = currCounter;
                        removeKnightRow = row;
                        removeKnightCol = col;
                        isHaveAttack = true;
                    }
                }
            }

            if (isHaveAttack)
            {
                matrix[removeKnightRow, removeKnightCol] = '0';
                counter++;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(counter);

    }

    static int IsHaveAttackTarget(char[,] matrix, int row, int col)
    {
        var counter = 0;
        //UpLeft
        if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
        {
            counter++;
        }
        //UpRight
        if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
        {
            counter++;
        }
        //LeftUp
        if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
        {
            counter++;
        }
        //LeftDown
        if(IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
        {
            counter++;
        }
        //RightUp
        if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
        {
            counter++;
        }
        //RightDown
        if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
        {
            counter++;
        }
        //DownLeft
        if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
        {
            counter++;
        }
        //DownRight
        if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
        {
            counter++;
        }

        return counter;
    }

    static bool IsInside(char[,] matrix, int row, int col)
    {
        var isInside = false;

        if (0 <= row && row < matrix.GetLength(0) && 
            0 <= col && col < matrix.GetLength(1))
        {
            isInside = true;
        }

        return isInside;
    }

    static char[,] ReadMatrix(int n)
    {
        var matrix = new char[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            var currRow = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currRow[col];
            }
        }

        return matrix;
    }
}