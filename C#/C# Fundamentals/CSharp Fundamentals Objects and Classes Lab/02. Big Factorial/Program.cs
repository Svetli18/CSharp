﻿using System;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        Console.WriteLine(result);
    }
}