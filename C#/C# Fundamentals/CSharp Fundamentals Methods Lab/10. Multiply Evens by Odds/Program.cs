using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            n = GetPositiveNumber(n);
        }

        int evensSum = GetSumOfEvenDigits(n);
        int oddsSum = GetSumOfOddDigits(n);

        int result = GetMultipleOfEvenAndOdds(evensSum, oddsSum);

        Console.WriteLine(result);

    }

    static int GetMultipleOfEvenAndOdds(int evensSum, int oddsSum)
    {
        return evensSum * oddsSum;
    }

    static int GetSumOfOddDigits(int n)
    {
        int sum = 0;

        while (n != 0)
        {
            int currentNumber = n % 10;
            n /= 10;

            if (currentNumber % 2 != 0)
            {
                sum += currentNumber;
            }

        }

        return sum;

    }

    static int GetSumOfEvenDigits(int n)
    {
        int sum = 0;

        while (n != 0)
        {
            int currentNumber = n % 10;
            n /= 10;

            if (currentNumber % 2 == 0)
            {
                sum += currentNumber;
            }

        }

        return sum;

    }

    static int GetPositiveNumber(int n)
    {
        return Math.Abs(n);
    }
}