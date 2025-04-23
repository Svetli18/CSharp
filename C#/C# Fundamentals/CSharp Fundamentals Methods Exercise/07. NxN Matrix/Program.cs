using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        PrintNumber(number);
    }

    static void PrintNumber(int number)
    {
        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < number; j++)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}