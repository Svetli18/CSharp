using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] bannedWords = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        string text = Console.ReadLine();

        bool IsReady = false;

        while (!IsReady)
        {
            foreach (var word in bannedWords)
            {
                if (!text.Contains(word))
                {
                    IsReady = true; 
                    break;
                }
                    
                    text = text.Replace(word, new string('*', word.Length));

            }

        }

        Console.WriteLine(text);
    }
}