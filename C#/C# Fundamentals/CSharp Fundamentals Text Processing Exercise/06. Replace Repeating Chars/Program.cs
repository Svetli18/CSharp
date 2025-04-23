using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        char prev = '\0';

        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];

            if (!current.Equals(prev))
            {
                sb.Append(current);
                prev = current;
            }
        }

        Console.WriteLine(sb.ToString());
    }
}