namespace Warships
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] array = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstAttack = new Queue<string>();
            Queue<string> secondAttack = new Queue<string>();
            GetAttackCoordinates(array, firstAttack, secondAttack);

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            int sunkShipsCount = 0;

            char[][] matrix = ReadMatrix(n, ref firstPlayerShips, ref secondPlayerShips);

            while (firstAttack.Any())
            {
                int[] firstAtackArgs = firstAttack.Dequeue()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstAttackRow = firstAtackArgs[0];
                int firstAttackCol = firstAtackArgs[1];

                if (IsInMatrix(n, firstAttackRow, firstAttackCol))
                {
                    if (matrix[firstAttackRow][firstAttackCol] == '#')
                    {
                        UpdateMatrix(n, ref firstPlayerShips, ref secondPlayerShips, ref sunkShipsCount, matrix, firstAttackRow, firstAttackCol);

                    }
                    else if (matrix[firstAttackRow][firstAttackCol] == '>')
                    {
                        matrix[firstAttackRow][firstAttackCol] = 'X';
                        sunkShipsCount++;
                        secondPlayerShips--;
                    }
                }

                int[] secondAttackArgs = new int[2] { -1, -1 };

                if (secondAttack.Any())
                {
                    secondAttackArgs = secondAttack.Dequeue()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                }

                int secondAttackRow = secondAttackArgs[0];
                int secondAttackCol = secondAttackArgs[1];

                if (IsInMatrix(n, secondAttackRow, secondAttackCol))
                {
                    if (matrix[secondAttackRow][secondAttackCol] == '#')
                    {
                        UpdateMatrix(n, ref firstPlayerShips, ref secondPlayerShips, ref sunkShipsCount, matrix, secondAttackRow, secondAttackCol);
                    }
                    else if (matrix[secondAttackRow][secondAttackCol] == '<')
                    {
                        matrix[secondAttackRow][secondAttackCol] = 'X';
                        sunkShipsCount++;
                        firstPlayerShips--;
                    }
                }

                if (firstPlayerShips == 0 || secondPlayerShips == 0)
                {
                    break;
                }

            }

            if (0 < firstPlayerShips && 0 < secondPlayerShips)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
            else if (0 < firstPlayerShips)
            {
                Console.WriteLine($"Player One has won the game! {sunkShipsCount} ships have been sunk in the battle.");
            }
            else if (0 < secondPlayerShips)
            {
                Console.WriteLine($"Player Two has won the game! {sunkShipsCount} ships have been sunk in the battle.");
            }

        }

        private static void UpdateMatrix(int n, ref int firstPlayerShips, ref int secondPlayerShips, ref int sunkShipsCount, char[][] matrix, int attackRow, int attackCol)
        {
            //centur
            matrix[attackRow][attackCol] = 'X';

            //up left
            if (IsInMatrix(n, attackRow - 1, attackCol - 1) &&
                matrix[attackRow - 1][attackCol - 1] == '<')
            {
                matrix[attackRow - 1][attackCol - 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //up
            if (IsInMatrix(n, attackRow - 1, attackCol) && 
                matrix[attackRow - 1][attackCol] == '<')
            {
                matrix[attackRow - 1][attackCol] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //up right
            if (IsInMatrix(n, attackRow - 1, attackCol + 1) &&
                matrix[attackRow - 1][attackCol + 1] == '<')
            {
                matrix[attackRow - 1][attackCol + 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //left
            if (IsInMatrix(n, attackRow, attackCol - 1) &&
                matrix[attackRow][attackCol - 1] == '<')
            {
                matrix[attackRow][attackCol - 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }            
            //right
            if (IsInMatrix(n, attackRow, attackCol + 1) &&
                matrix[attackRow][attackCol + 1] == '<')
            {
                matrix[attackRow][attackCol + 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //down left
            if (IsInMatrix(n, attackRow + 1, attackCol - 1) &&
                matrix[attackRow + 1][attackCol - 1] == '<')
            {
                matrix[attackRow + 1][attackCol - 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //down
            if (IsInMatrix(n, attackRow + 1, attackCol) &&
                matrix[attackRow + 1][attackCol] == '<')
            {
                matrix[attackRow + 1][attackCol] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }
            //down right
            if (IsInMatrix(n, attackRow + 1, attackCol + 1) &&
                matrix[attackRow + 1][attackCol + 1] == '<')
            {
                matrix[attackRow + 1][attackCol + 1] = 'X';
                sunkShipsCount++;
                firstPlayerShips--;
            }

            // ------ NOW SECOND PLAYER TEST--------

            //up left
            if (IsInMatrix(n, attackRow - 1, attackCol - 1) &&
                matrix[attackRow - 1][attackCol - 1] == '>')
            {
                matrix[attackRow - 1][attackCol - 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //up
            if (IsInMatrix(n, attackRow - 1, attackCol) &&
                matrix[attackRow - 1][attackCol] == '>')
            {
                matrix[attackRow - 1][attackCol] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //up right
            if (IsInMatrix(n, attackRow - 1, attackCol + 1) &&
                matrix[attackRow - 1][attackCol + 1] == '>')
            {
                matrix[attackRow - 1][attackCol + 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //left
            if (IsInMatrix(n, attackRow, attackCol - 1) &&
                matrix[attackRow][attackCol - 1] == '>')
            {
                matrix[attackRow][attackCol - 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //right
            if (IsInMatrix(n, attackRow, attackCol + 1) &&
                matrix[attackRow][attackCol + 1] == '>')
            {
                matrix[attackRow][attackCol + 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //down left
            if (IsInMatrix(n, attackRow + 1, attackCol - 1) &&
                matrix[attackRow + 1][attackCol - 1] == '>')
            {
                matrix[attackRow + 1][attackCol - 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //down
            if (IsInMatrix(n, attackRow + 1, attackCol) &&
                matrix[attackRow + 1][attackCol] == '>')
            {
                matrix[attackRow + 1][attackCol] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }
            //down right
            if (IsInMatrix(n, attackRow + 1, attackCol + 1) &&
                matrix[attackRow + 1][attackCol + 1] == '>')
            {
                matrix[attackRow + 1][attackCol + 1] = 'X';
                sunkShipsCount++;
                secondPlayerShips--;
            }

        }

        private static void GetAttackCoordinates(string[] array, Queue<string> firstAtack, Queue<string> secondAtack)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    firstAtack.Enqueue(array[i]);
                    continue;
                }

                secondAtack.Enqueue(array[i]);
            }
        }

        private static bool IsInMatrix(int n, int atackRow, int atackCol)
        {
            return 0 <= atackRow && atackRow < n && 0 <= atackCol && atackCol < n;
        }

        private static char[][] ReadMatrix(int n, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            char[][] matrix = new char[n][];

            for (int r = 0; r < matrix.Length; r++)
            {
                char[] curentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int c = 0; c < curentRow.Length; c++)
                {
                    if (curentRow[c] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (curentRow[c] == '>')
                    {
                        secondPlayerShips++;
                    }
                }

                matrix[r] = curentRow;

            }

            return matrix;
        }
    }
}
