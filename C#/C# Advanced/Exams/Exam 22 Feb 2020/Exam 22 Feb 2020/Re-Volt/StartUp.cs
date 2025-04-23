namespace ReVolt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            int row = -1;
            int col = -1;
            bool isPlayerWon = false;

            char[][] matrix = ReadMatrix(n, ref row, ref col);


            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (row - 1 < 0 && matrix[n - 1][col] != 'T')
                    {
                        matrix[row][col] = '-';
                        row = n - 1;

                        if (matrix[row][col] == 'B')
                        {
                            row--;
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';

                    }
                    else if (matrix[row - 1][col] != 'T')
                    {
                        matrix[row][col] = '-';
                        row--;

                        if (matrix[row][col] == 'B')
                        {
                            row--;

                            if (row < 0)
                            {
                                row = n - 1;
                            }
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }

                }
                else if (command == "down")
                {
                    if (n == row + 1 && matrix[0][col] != 'T')
                    {
                        matrix[row][col] = '-';
                        row = 0;

                        if (matrix[row][col] == 'B')
                        {
                            row++;
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                    else if (matrix[row + 1][col] != 'T')
                    {
                        matrix[row][col] = '-';
                        row++;

                        if (matrix[row][col] == 'B')
                        {
                            row++;

                            if (row == n)
                            {
                                row = 0;
                            }
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                }
                else if (command == "left")
                {
                    if (col - 1 < 0 && matrix[row][n - 1] != 'T')
                    {
                        matrix[row][col] = '-';
                        col = n - 1;

                        if (matrix[row][col] == 'B')
                        {
                            col--;
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                    else if (matrix[row][col - 1] != 'T')
                    {
                        matrix[row][col] = '-';
                        col--;

                        if (matrix[row][col] == 'B')
                        {
                            col--;

                            if (col < 0)
                            {
                                col = n - 1;
                            }
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                }
                else if (command == "right")
                {
                    if (n == col + 1 && matrix[row][0] != 'T')
                    {
                        matrix[row][col] = '-';
                        col = 0;

                        if (matrix[row][col] == 'B')
                        {
                            col++;
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                    else if (matrix[row][col + 1] != 'T')
                    {
                        matrix[row][col] = '-';
                        col++;

                        if (matrix[row][col] == 'B')
                        {
                            col++;

                            if (col == n)
                            {
                                col = 0;
                            }
                        }
                        if (matrix[row][col] == 'F')
                        {
                            matrix[row][col] = 'f';
                            isPlayerWon = true;
                            break;
                        }

                        matrix[row][col] = 'f';
                    }
                }
            }

            if (isPlayerWon)
            {
                Console.WriteLine("Player won!");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
            }

        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var currRow in matrix)
            {
                Console.WriteLine(string.Join("", currRow));
            }
        }

        public static char[][] ReadMatrix(int n, ref int playerRow, ref int playerCol)
        {
            char[][] matrix = new char[n][];

            bool isPlayerFaund = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                string currRow = Console.ReadLine();

                if (!isPlayerFaund)
                {
                    for (int col = 0; col < currRow.Length; col++)
                    {
                        if (currRow[col] == 'f')
                        {
                            playerRow = row;
                            playerCol = col;
                            isPlayerFaund = true;
                            break;
                        }
                    }
                }

                matrix[row] = currRow.ToCharArray();
            }

            return matrix;
        }
    }
}
