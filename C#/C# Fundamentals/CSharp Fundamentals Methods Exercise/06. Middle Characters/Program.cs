using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        PrintMiddleOfTheText(text);
    }

    static void PrintMiddleOfTheText(string text)
    {
        if (text.Length % 2 == 0)
        {
            Console.WriteLine(text[text.Length / 2 - 1] + "" + text[text.Length / 2]);
        }
        else
        {
            Console.WriteLine(text[text.Length / 2]);
        }
    }
}