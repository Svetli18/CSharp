using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int numb1 = int.Parse(Console.ReadLine());
        int numb2 = int.Parse(Console.ReadLine());
        int numb3 = int.Parse(Console.ReadLine());

        PrintSmallestNumber(numb1, numb2, numb3);

    }

    static void PrintSmallestNumber(int numb1, int numb2, int numb3)
    {
        int result = Math.Min(numb1, Math.Min(numb2, numb3));

        Console.WriteLine(result);

    }
}