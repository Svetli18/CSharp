﻿using System;

internal class Program
{
    private static void Main(string[] args)
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double area = GetRectangleArea(width, height);

        Console.WriteLine(area);

    }

    static double GetRectangleArea(double width, double height)
    {
        double result = width * height;

        return result;

    }
}