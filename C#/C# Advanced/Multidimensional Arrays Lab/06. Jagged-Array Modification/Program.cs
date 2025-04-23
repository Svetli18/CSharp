using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var jagged = GetJaggedArray(n);

        var cmd = "";
        while ((cmd = Console.ReadLine()) != "END")
        {
            var cmdArgs = cmd.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var command = cmdArgs[0];

            if (command == "Add")
            {
                var row  = int.Parse(cmdArgs[1]);
                var col = int.Parse(cmdArgs[2]);
                var value = int.Parse(cmdArgs[3]);

                if (0 <= row && row < jagged.Length &&
                    0 <= col && col < jagged[row].Length)
                {
                    jagged[row][col] += value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

            }
            else if (command == "Subtract")
            {
                var row = int.Parse(cmdArgs[1]);
                var col = int.Parse(cmdArgs[2]);
                var value = int.Parse(cmdArgs[3]);

                if (0 <= row && row < jagged.Length &&
                    0 <= col && col < jagged[row].Length)
                {
                    jagged[row][col] -= value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

        }

        PrintJagged(jagged);
    }

    static void PrintJagged(int[][] jagged)
    {
        foreach (int[] row in jagged)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }

    static int[][] GetJaggedArray(int n)
    {
        var jagged = new int[n][];

        for (int row = 0; row < jagged.Length; row++)
        {
            var currRow = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            jagged[row] = currRow;

        }

        return jagged;
    }
}