using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        PrintSignOfIntegerNumber(n);

    }

    static void PrintSignOfIntegerNumber(int n)
    {
        if (IsPositive(n))
        {
            Console.WriteLine($"The number {n} is positive.");
        }
        else if (IsNegative(n))
        {
            Console.WriteLine($"The number {n} is negative.");
        }
        else if (IsZero(n))
        {
            Console.WriteLine($"The number {n} is zero.");
        }

    }

    static bool IsPositive(int n)
    {
        return 0 < n;
    }

    static bool IsNegative(int n)
    {
        return n < 0;
    }

    static bool IsZero(int n)
    {
        return n == 0;
    }
}