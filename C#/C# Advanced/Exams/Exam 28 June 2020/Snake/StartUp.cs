namespace Snake
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int foodCouter = 0;

            int row = -1;
            int col = -1;
            int b1R = -1;
            int b1C = -1;
            int b2R = -1;
            int b2C = -1;

            bool isOutSide = false;

            char[][] matrix = ReadMatrix(n, ref row, ref col, ref b1R, ref b1C, ref b2R, ref b2C);

            while (foodCouter < 10)
            {
                string move = Console.ReadLine();

                matrix[row][col] = '.';

                if (move == "up")
                {
                    row--;

                    if (row < 0)
                    {
                        isOutSide = true;
                        break;
                    }
                    if (matrix[row][col] == '*')
                    {
                        foodCouter++;
                    }
                    else if (matrix[row][col] == 'B')
                    {
                        BurrowsMove(ref row, ref col, b1R, b1C, b2R, b2C, matrix);
                    }

                    matrix[row][col] = 'S';

                }
                else if (move == "down")
                {
                    row++;

                    if (row == n)
                    {
                        isOutSide = true;
                        break;
                    }
                    if (matrix[row][col] == '*')
                    {
                        foodCouter++;
                    }
                    else if (matrix[row][col] == 'B')
                    {
                        BurrowsMove(ref row, ref col, b1R, b1C, b2R, b2C, matrix);
                    }

                    matrix[row][col] = 'S';

                }
                else if (move == "left")
                {
                    col--;

                    if (col < 0)
                    {
                        isOutSide = true;
                        break;
                    }
                    if (matrix[row][col] == '*')
                    {
                        foodCouter++;
                    }
                    else if (matrix[row][col] == 'B')
                    {
                        BurrowsMove(ref row, ref col, b1R, b1C, b2R, b2C, matrix);
                    }

                    matrix[row][col] = 'S';

                }
                else if (move == "right")
                {
                    col++;

                    if (col == n)
                    {
                        isOutSide = true;
                        break;
                    }
                    if (matrix[row][col] == '*')
                    {
                        foodCouter++;
                    }
                    else if (matrix[row][col] == 'B')
                    {
                        BurrowsMove(ref row, ref col, b1R, b1C, b2R, b2C, matrix);
                    }

                    matrix[row][col] = 'S';

                }
            }

            if (isOutSide)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodCouter == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCouter}");

            foreach (var currRow in matrix)
            {
                Console.WriteLine(string.Join("", currRow));
            }

        }

        private static void BurrowsMove(ref int row, ref int col, int b1R, int b1C, int b2R, int b2C, char[][] matrix)
        {
            if (row == b1R && col == b1C)
            {
                matrix[row][col] = '.';
                row = b2R;
                col = b2C;

                matrix[row][col] = 'S';
            }
            else if (row == b2R && col == b2C)
            {
                matrix[row][col] = '.';
                row = b1R;
                col = b1C;

                matrix[row][col] = 'S';
            }
        }

        private static char[][] ReadMatrix(int n, ref int row, ref int col, ref int b1R, ref int b1C, ref int b2R, ref int b2C)
        {
            char[][] matrix = new char[n][];

            for (int r = 0; r < matrix.Length; r++)
            {
                string currentRow = Console.ReadLine();

                for (int c = 0; c < currentRow.Length; c++)
                {
                    if (currentRow[c] == 'S')
                    {
                        row = r;
                        col = c;
                    }
                    else if (currentRow[c] == 'B')
                    {
                        if (b1R == -1 && b1C == -1)
                        {
                            b1R = r;
                            b1C = c;
                        }
                        else
                        {
                            b2R = r;
                            b2C = c;
                        }
                    }
                }

                matrix[r] = currentRow.ToCharArray();

            }

            return matrix;
        }
    }
}
