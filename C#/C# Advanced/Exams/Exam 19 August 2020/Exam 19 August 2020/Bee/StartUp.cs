namespace Bee
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int beeRow = -1;
            int beeCol = -1;

            char[][] matrix = ReadMatrix(n, ref beeRow, ref beeCol);

            bool isBeeGotLost = false;
            int polinationedFlowersCounter = 0;

            string move;
            while ((move = Console.ReadLine()) != "End")
            {
                matrix[beeRow][beeCol] = '.';

                if (move == "up")
                {
                    beeRow--;
                    isBeeGotLost = BeeOutSideTheMatrixChecker(beeRow, n);
                    if (!isBeeGotLost && matrix[beeRow][beeCol] == 'O')
                    {
                        matrix[beeRow][beeCol] = '.';
                        beeRow--;
                    }
                }
                else if (move == "down")
                {
                    beeRow++;
                    isBeeGotLost = BeeOutSideTheMatrixChecker(beeRow, n);
                    if (!isBeeGotLost && matrix[beeRow][beeCol] == 'O')
                    {
                        matrix[beeRow][beeCol] = '.';
                        beeRow++;
                    }
                }
                else if (move == "left")
                {
                    beeCol--;
                    isBeeGotLost = BeeOutSideTheMatrixChecker(beeCol, n);
                    if (!isBeeGotLost && matrix[beeRow][beeCol] == 'O')
                    {
                        matrix[beeRow][beeCol] = '.';
                        beeCol--;
                    }
                }
                else if (move == "right")
                {
                    beeCol++;
                    isBeeGotLost = BeeOutSideTheMatrixChecker(beeCol, n);
                    if (!isBeeGotLost && matrix[beeRow][beeCol] == 'O')
                    {
                        matrix[beeRow][beeCol] = '.';
                        beeCol++;
                    }
                }

                if (isBeeGotLost)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow][beeCol] == 'f')
                {
                    polinationedFlowersCounter++;
                }

                matrix[beeRow][beeCol] = 'B';

            }

            if (5 <= polinationedFlowersCounter)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowersCounter} flowers!");
            }
            else if (polinationedFlowersCounter < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowersCounter} flowers more");
            }

            foreach (var currRow in matrix)
            {
                Console.WriteLine(string.Join("", currRow));
            }

        }

        private static bool BeeOutSideTheMatrixChecker(int beePosition, int n)
        {
            return beePosition < 0 || n == beePosition;
        }

        private static char[][] ReadMatrix(int n, ref int beeRow, ref int beeCol)
        {
            char[][] matrix = new char[n][];

            bool beeFinted = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                string currRow = Console.ReadLine();

                if (!beeFinted)
                {
                    for (int c = 0; c < currRow.Length; c++)
                    {
                        char current = currRow[c];

                        if (current == 'B')
                        {
                            beeRow = r;
                            beeCol = c;
                            beeFinted = true;
                            break;
                        }
                    }
                }

                matrix[r] = currRow.ToCharArray();

            }

            return matrix;
        }
    }
}
