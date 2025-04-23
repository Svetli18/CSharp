namespace Selling
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int row = -1;
            int col = -1;
            int money = 0;
            bool isOutSideTheMatrix = false;

            char[][] matrix = GetReadMatrix(n, ref row, ref col);

            while (true)
            {

                matrix[row][col] = '-';

                string move = Console.ReadLine();

                if (move == "up")
                {
                    row--;
                    isOutSideTheMatrix = CheckIsOutSideTheMatrix(row, n);
                }
                else if (move == "down")
                {
                    row++;
                    isOutSideTheMatrix = CheckIsOutSideTheMatrix(row, n);

                }
                else if (move == "left")
                {
                    col--;
                    isOutSideTheMatrix = CheckIsOutSideTheMatrix(col, n);
                }
                else if (move == "right")
                {
                    col++;
                    isOutSideTheMatrix = CheckIsOutSideTheMatrix(col, n);
                }

                if (isOutSideTheMatrix)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (matrix[row][col] == 'O')
                {
                    matrix[row][col] = '-';
                    UpdateMatrix(matrix, ref row, ref col);
                }

                if (char.IsDigit(matrix[row][col]))
                {
                    money += int.Parse(matrix[row][col].ToString());
                }

                matrix[row][col] = 'S';

                if (50 <= money)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");

            foreach (var curentRow in matrix)
            {
                Console.WriteLine(string.Join("", curentRow));
            }

        }

        private static void UpdateMatrix(char[][] matrix, ref int row, ref int col)
        {
            bool isReady = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 'O')
                    {
                        row = r;
                        col = c;
                        matrix[row][col] = 'S';
                        isReady = true;
                        break;
                    }
                }

                if (isReady)
                {
                    break;
                }

            }
        }

        private static bool CheckIsOutSideTheMatrix(int direction, int n)
        {
            return direction < 0 || direction == n;
        }

        private static char[][] GetReadMatrix(int n, ref int row, ref int col)
        {
            char[][] matrix = new char[n][];

            bool isFaindPlayer = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                string curentRow = Console.ReadLine();

                if (!isFaindPlayer)
                {
                    for (int c = 0; c < curentRow.Length; c++)
                    {
                        if (curentRow[c] == 'S')
                        {
                            row = r;
                            col = c;
                            isFaindPlayer = true;
                        }
                    }
                }

                matrix[r] = curentRow.ToCharArray();

            }

            return matrix;
        }
    }
}
