using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        int result = GetVowelsCount(text);

        Console.WriteLine(result);

    }

    static int GetVowelsCount(string text)
    {
        int count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'A' || text[i] == 'E' || text[i] == 'I' || 
                text[i] == 'O' || text[i] == 'U' || text[i] == 'Y' ||
                text[i] == 'a' || text[i] == 'e' || text[i] == 'i' ||
                text[i] == 'o' || text[i] == 'u' || text[i] == 'y')
            {
                count++;
            }

        }

        return count;

    }
}