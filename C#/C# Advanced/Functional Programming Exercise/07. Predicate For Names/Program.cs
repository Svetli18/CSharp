using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<string, int> parser = n => int.Parse(n);

        int n = parser(Console.ReadLine());

        Func<string, bool> predicate = s => s.Length <= n;

        Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(predicate)
            .ToList()
            .ForEach(name => Console.WriteLine(name));

    }
}