using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        StringBuilder digits = new StringBuilder();
        StringBuilder letters = new StringBuilder();
        StringBuilder chars = new StringBuilder();

        foreach (var character in input)
        {
            if (char.IsDigit(character))
            {
                digits.Append(character);
            }
            else if (char.IsLetter(character))
            {
                letters.Append(character);
            }
            else
            {
                chars.Append(character);
            }
        }

        Console.WriteLine(digits.ToString());
        Console.WriteLine(letters.ToString());
        Console.WriteLine(chars.ToString());

    }
}