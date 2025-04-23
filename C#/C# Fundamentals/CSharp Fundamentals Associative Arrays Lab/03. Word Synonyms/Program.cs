using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();
            string synonum = Console.ReadLine();

            if (!dict.ContainsKey(word))
            {
                dict[word] = new List<string>();
            }

            dict[word].Add(synonum);

        }

        foreach (var kvp in dict)
        {
            Console.Write($"{kvp.Key} - ");
            Console.WriteLine(string.Join(", ", kvp.Value));
        }

    }
}