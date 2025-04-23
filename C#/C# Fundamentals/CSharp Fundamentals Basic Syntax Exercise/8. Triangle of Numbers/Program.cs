namespace TriangleOfNumbers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {

                for (int j = 1; j <= i; j++)
                {
                    if (j == 1)
                    {
                        Console.Write($"{i}");
                    }
                    else 
                    {
                        Console.Write($" {i}");
                    }            
                }
                Console.WriteLine();
            }
        }
    }
}

