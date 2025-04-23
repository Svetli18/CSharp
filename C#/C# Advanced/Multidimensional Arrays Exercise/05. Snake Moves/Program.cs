using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var area = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var r = area[0];
        var c = area[1];

        var input = Console.ReadLine();

        var queue = new Queue<char>(input);

        var matrix = GetMatrix(r, c, queue);

        PrintMatrix(matrix);
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    static char[,] GetMatrix(int r, int c, Queue<char> queue)
    {
        var matrix = new char[r, c];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var currCh = queue.Dequeue();
                if (row % 2 != 0)
                {
                    matrix[row, matrix.GetLength(1) - 1 - col] = currCh;
                }
                else
                {
                    matrix[row, col] = currCh;
                }
                queue.Enqueue(currCh);
            }
        }

        return matrix;
    }
}