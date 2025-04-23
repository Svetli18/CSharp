using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var matrix = GetMatrix(n, n);

        var element = char.Parse(Console.ReadLine());

        var r = 0;
        var c = 0;

        var isFind = false;

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {

                var currElement = matrix[row, col];

                if (currElement == element)
                {
                    isFind = true;
                    r = row;
                    c = col;
                    break;
                }

            }

            if (isFind)
            {
                break;
            }

        }

        if (isFind)
        {
            Console.WriteLine($"({r}, {c})");
        }
        else
        {
            Console.WriteLine($"{element} does not occur in the matrix");
        }

    }

    static char[,] GetMatrix(int n1, int n2)
    {
        var matrix = new char[n1, n2];

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            var current = Console.ReadLine();

            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = current[col];
            }

        }

        return matrix;
    }
}