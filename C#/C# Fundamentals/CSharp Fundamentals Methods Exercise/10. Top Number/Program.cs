using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        PrintTopNumbers(n);
    }

    static void PrintTopNumbers(int n)
    {
        for (int i = 1; i <= n; i++)
        {

            bool isHaveOdd = false;
            int sum = 0;
            int currentNumber = i;

            while (0 < currentNumber)
            {
                int current = currentNumber % 10;
                currentNumber = currentNumber / 10;
                sum += current;

                if (current % 2 != 0)
                {
                    isHaveOdd = true;
                }

                if (sum % 8 == 0 && isHaveOdd)
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}