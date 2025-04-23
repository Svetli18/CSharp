using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string command = Console.ReadLine();

        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());

        switch (command)
        {
            case "add": PrintCalculateAdd(number1, number2);
                break;
            case "subtract": PrintCalculateSubtract(number1, number2);
                break;
            case "multiply": PrintCalculateMultiply(number1, number2);
                break;
            case "divide": PrintCalculateDivide(number1, number2);
                break;
        }

    }

    static void PrintCalculateAdd(double number1, double number2)
    {
        double result = number1 + number2;

        Console.WriteLine(result);
    }

    static void PrintCalculateSubtract(double number1, double number2)
    {
        double result = number1 - number2;

        Console.WriteLine(result);
    }

    static void PrintCalculateMultiply(double number1, double number2)
    {
        double result = number1 * number2;

        Console.WriteLine(result);
    }

    static void PrintCalculateDivide(double number1, double number2)
    {
        double result = number1 / number2;

        Console.WriteLine(result);
    }

}