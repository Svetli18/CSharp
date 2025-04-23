using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int numb1 = int.Parse(Console.ReadLine());
        int numb2 = int.Parse(Console.ReadLine());
        int numb3 = int.Parse(Console.ReadLine());

        int sumFromAdd = GetSumFromAdd(numb1, numb2);

        int sumFromSubtract = GetSumFromSubtract(sumFromAdd, numb3);

        Console.WriteLine(sumFromSubtract);
    }

    static int GetSumFromSubtract(int sumFromAdd, int numb3)
    {
        return sumFromAdd - numb3;
    }

    static int GetSumFromAdd(int numb1, int numb2)
    {
        return numb1 + numb2;
    }
}