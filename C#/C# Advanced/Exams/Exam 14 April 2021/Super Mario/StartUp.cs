namespace Super_Mario
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            bool tryParseLives = int.TryParse(Console.ReadLine(), out int lives);

            bool tryParseN = int.TryParse(Console.ReadLine(), out int n);

            int row = -1;
            int col = -1;

            bool isMarioWins = false;

            char[][] matrix = GetMatrix(n, ref row, ref col);

            try
            {
                while (0 < lives)
                {
                    string[] command = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string move = command[0];

                    bool isValid1 = int.TryParse(command[1], out int enemyRow);
                    bool isValid2 = int.TryParse(command[2], out int enemyCol);

                    if (isValid1 && isValid2 && IsInsideMatrix(n, enemyRow, enemyCol))
                    {
                        matrix[enemyRow][enemyCol] = 'B';
                    }

                    if (move == "W")//up
                    {
                        if (IsInsideMatrix(n, row - 1, col))
                        {
                            matrix[row][col] = '-';
                            row--;
                        }
                    }
                    else if (move == "S")//down
                    {
                        if (IsInsideMatrix(n, row + 1, col))
                        {
                            matrix[row][col] = '-';
                            row++;
                        }
                    }
                    else if (move == "A")//left
                    {
                        if (IsInsideMatrix(n, row, col - 1))
                        {
                            matrix[row][col] = '-';
                            col++;
                        }
                    }
                    else if (move == "D")//right
                    {
                        if (IsInsideMatrix(n, row, col + 1))
                        {
                            matrix[row][col] = '-';
                            col++;
                        }
                    }

                    lives--;

                    if (matrix[row][col] == 'B')
                    {
                        lives -= 2;
                    }
                    if (matrix[row][col] == 'P')
                    {
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                        isMarioWins = true;
                        matrix[row][col] = '-';
                        break;
                    }

                    matrix[row][col] = 'M';

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (!isMarioWins && lives <= 0)
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"Mario died at {row};{col}.");
            }

            foreach (var currRow in matrix)
            {
                Console.WriteLine(string.Join("", currRow));
            }

        }

        private static bool IsInsideMatrix(int n, int enemyRow, int enemyCol)
        {
            return 0 <= enemyRow && enemyRow < n && 0 <= enemyCol && enemyCol < n;
        }

        private static char[][] GetMatrix(int n, ref int row, ref int col)
        {
            char[][] matrix = new char[n][];

            bool isMarioFaind = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                string currentRow = Console.ReadLine();

                if (!isMarioFaind)
                {
                    for (int c = 0; c < currentRow.Length; c++)
                    {
                        if (currentRow[c] == 'M')
                        {
                            row = r;
                            col = c;
                            isMarioFaind = true;
                            break;
                        }
                    }
                }

                matrix[r] = currentRow.ToCharArray();

            }

            return matrix;

        }
    }
}
