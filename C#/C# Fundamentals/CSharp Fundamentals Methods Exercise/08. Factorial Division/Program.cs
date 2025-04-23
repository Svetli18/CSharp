using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int numb1 = int.Parse(Console.ReadLine());
        int numb2 = int.Parse(Console.ReadLine());

        decimal resultNumber1 = GetFactorialResult(numb1);
        decimal resultNumber2 = GetFactorialResult(numb2);

        decimal result = GetDivideResult(resultNumber1, resultNumber2);

        Console.WriteLine($"{result:F2}");
    }

    static decimal GetDivideResult(decimal resultNumber1, decimal resultNumber2)
    {
        return resultNumber1 / resultNumber2;
    }

    static decimal GetFactorialResult(int number)
    {
        if (number == 1)
        {
            return 1;
        }

        return number * GetFactorialResult(number - 1);
    }
}