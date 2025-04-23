namespace ExactSumOfRealNumbers
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal result = 0;

            for (int i = 0; i < n; i++)
            {
                decimal currentNumber = decimal.Parse(Console.ReadLine());

                result += currentNumber;
            }

            Console.WriteLine(result);
        }
    }
}