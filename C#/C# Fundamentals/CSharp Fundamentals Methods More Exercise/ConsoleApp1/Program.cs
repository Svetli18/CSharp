using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());

        string result = GetSignResult(n, n2, n3);

        Console.WriteLine(result);

    }

    static string GetSignResult(int n, int n2, int n3)
    {
        if (0 < n && 0 < n2 && 0 < n3)
        {
            return "positive";
        }
        else if (n == 0 || n2 == 0 || n3 == 0)
        {
            return "zero";
        }

        return "negative";

    }
}