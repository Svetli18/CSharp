namespace RefactorSpecialNumbers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {

                int sum = 0;
                int currentNumber = i;

                while (0 < currentNumber)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}