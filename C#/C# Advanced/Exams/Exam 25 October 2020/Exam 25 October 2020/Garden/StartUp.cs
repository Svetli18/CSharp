namespace Garden
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] matrixDimension = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] garden = GetGardenMatrix(matrixDimension[0], matrixDimension[1]);

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                bool isOutSideOfTheGarden = IsOutSideOfTheGarden(row, matrixDimension[0], col, matrixDimension[1]);

                if (isOutSideOfTheGarden)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row][col]--;

                UpdaiteGarden(garden, row, col);

            }

            PrintGarden(garden);

        }

        private static void PrintGarden(int[][] garden)
        {
            for (int r = 0; r < garden.Length; r++)
            {
                for (int c = 0; c < garden[r].Length; c++)
                {
                    if (c == 0)
                    {
                        Console.Write(garden[r][c]);
                        continue;
                    }

                    Console.Write(" " + garden[r][c]);
                }
                Console.WriteLine();
            }
        }

        private static void UpdaiteGarden(int[][] garden, int row, int col)
        {
            for (int r = 0; r < garden.Length; r++)
            {
                garden[r][col]++;
            }

            for (int c = 0; c < garden[row].Length; c++)
            {
                garden[row][c]++;
            }
        }

        private static bool IsOutSideOfTheGarden(int row, int v1, int col, int v2)
        {
            return row < 0 || v1 <= row || col < 0 || v2 <= col;
        }

        private static int[][] GetGardenMatrix(int v1, int v2)
        {
            int[][] matrix = new int[v1][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = new int[v2];
            }

            return matrix;
        }
    }
}
