using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int numb1 = int.Parse(Console.ReadLine());

        string operation = Console.ReadLine();

        int numb2 = int.Parse(Console.ReadLine());

        int result = Calculate(numb1, numb2, operation);

        Console.WriteLine(result);

    }

    static int Calculate(int numb1, int numb2, string? operation)
    {
        switch (operation)
        {
            case "+": return numb1 + numb2;
            case "-": return numb1 - numb2;
            case "*": return numb1 * numb2;
            case "/": return numb1 / numb2;
        }

        return 0;

    }
}