using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());

        var jagged = GetJaggetArray(rows);

        var command = "";
        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var currCommand = commandArgs[0];
            var row = int.Parse(commandArgs[1]);
            var col = int.Parse(commandArgs[2]);
            var value = int.Parse(commandArgs[3]);

            if (currCommand == "Add" && 
                0 <= row && row < jagged.Length && 
                0 <= col && col < jagged[row].Length)
            {
                jagged[row][col] += value;
            }
            else if (currCommand == "Subtract" && 
                0 <= row && row < jagged.Length &&
                0 <= col && col < jagged[row].Length)
            {
                jagged[row][col] -= value;
            }
        }

        PrintJaggedArray(jagged);
    }

    static void PrintJaggedArray(int[][] jagged)
    {
        foreach (var row in jagged) 
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }

    static int[][] GetJaggetArray(int rows)
    {
        var jagged = new int[rows][];

        for (int row = 0; row < jagged.Length; row++)
        {
            var currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            jagged[row] = new int[currentRow.Length];

            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] = currentRow[col];
            }
        }

        for (int row = 0; row < jagged.Length - 1; row++)
        {
            if (jagged[row].Length == jagged[row + 1].Length)
            {
                jagged[row] = jagged[row].Select(e => e * 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(e => e * 2).ToArray();
            }
            else
            {
                jagged[row] = jagged[row].Select(e => e / 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(e => e / 2).ToArray();
            }
        }

        return jagged;
    }
}