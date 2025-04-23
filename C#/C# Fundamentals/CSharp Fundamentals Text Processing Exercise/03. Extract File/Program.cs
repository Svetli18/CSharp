using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] path = Console.ReadLine()
            .Split('\\', StringSplitOptions.RemoveEmptyEntries);

        string[] file = path.Last().Split('.', StringSplitOptions.RemoveEmptyEntries);

        string fileName = string.Join('.', file.Take(file.Length - 1));
        string extension = file.Last();

        Console.WriteLine($"File name: {fileName}");
        Console.WriteLine($"File extension: {extension}");

    }
}