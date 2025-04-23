using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int cnt = 1;

        RecursionMetod(cnt, n);
    }

    static void RecursionMetod(int cnt, int n)
    {
        if (n < cnt)
        {
            return;
        }

        PrintingTriangle(cnt);
        RecursionMetod(cnt + 1, n);
        PrintingTriangle(cnt - 1);
    }

    static void PrintingTriangle(int cnt)
    {
        for (int i = 1; i <= cnt; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}