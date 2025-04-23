using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] words = Console.ReadLine()
            .Split(" ", StringSplitOptions.None);

        StringBuilder sb = new StringBuilder();

        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(word);
            }
        }

        Console.WriteLine(sb.ToString());
    }
}