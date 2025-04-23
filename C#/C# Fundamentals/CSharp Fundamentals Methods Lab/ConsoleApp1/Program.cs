using System;

internal class Program
{
    private static void Main(string[] args)
    {
        double n1 = double.Parse(Console.ReadLine());

        double n2 = double.Parse(Console.ReadLine());

        double result = GetPower(n1, n2);

        Console.WriteLine(result);
    }

    static double GetPower(double n1, double n2)
    {
        double result = Math.Pow(n1, n2);

        return result;

    }
}