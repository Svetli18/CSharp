using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        int count = int.Parse(Console.ReadLine());

        string result = PrintTextCountTimes(text, count);

        Console.WriteLine(result);

    }

    static string PrintTextCountTimes(string text, int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += text;
        }

        return result;

    }
}