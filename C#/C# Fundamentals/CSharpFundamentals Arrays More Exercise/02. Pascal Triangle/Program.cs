namespace PascalTriangle
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //With Array!!!
            ArrayPascalTrianglePrint(n);

            //With Matrix!!!
            MatrixPascalTrianglePrint(0);

            //With JaggedArray!!!
            JaggedArrayPascalTrianglePrint(0);

        }

        private static void ArrayPascalTrianglePrint(int n)
        {
            int[] exArray = new int[1];

            for (int i = 0; i < n; i++)
            {
                int[] currentArray = new int[i + 1];


                for (int j = 0; j < currentArray.Length; j++)
                {
                    if (0 < j && j < currentArray.Length - 1)
                    {
                        currentArray[j] = exArray[j - 1] + exArray[j];
                        continue;
                    }

                    currentArray[j] = 1;

                }

                Console.WriteLine(string.Join(" ", currentArray));
                exArray = currentArray.ToArray();

            }
        }

        private static void MatrixPascalTrianglePrint(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (0 < j && j < i)
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = 1;
                    }

                }

            }

            string[] result = new string[n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (0 < matrix[i, j])
                    {
                        result[j] = matrix[i, j].ToString();
                    }
                }

                Console.WriteLine(string.Join(" ", result));

            }
        }

        private static void JaggedArrayPascalTrianglePrint(int n)
        {
            int[][] jaggedArray = new int[n][];

            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                jaggedArray[i] = new int[i + 1];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (0 < j && j < jaggedArray[i].Length - 1)
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                        continue;
                    }

                    jaggedArray[i][j] = 1;

                }
            }

            foreach (var jagg in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", jagg));
            }
        }
    }
}