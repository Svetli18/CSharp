using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var pascalTriangle = GetPascalTriangle(n);

        PrintPascalTriangle(pascalTriangle);

    }

    static void PrintPascalTriangle(long[][] pascalTriangle)
    {
        foreach (long[] row in pascalTriangle)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }

    static long[][] GetPascalTriangle(int n)
    {
        var jagged = new long[n][];
        var c = 1;

        for (int row = 0; row < jagged.Length; row++)
        {
            jagged[row] = new long[c++];

            for (int col = 0; col < jagged[row].Length; col++)
            {
                if (row == 0)
                {
                    jagged[row][col] = 1;
                }
                else if (row == 1)
                {
                    jagged[row][col] = 1;
                }
                else if(2 <= row)
                {
                    if(col == 0 || col == jagged[row].Length - 1)
                    {
                        jagged[row][col] = 1;
                    }
                    else
                    {
                        jagged[row][col] = jagged[row - 1][col - 1] + jagged[row - 1][col];
                    }
                }
            }
        }

        return jagged;
    }
}