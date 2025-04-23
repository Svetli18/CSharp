namespace SpecialNumbers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int sum = 0;

                while (0 < currentNumber)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                bool isSpecialNumber = sum == 5 || sum == 7 || sum == 11;

                Console.WriteLine($"{i} -> {isSpecialNumber}");
            }
        }
    }
}