using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<string, int> parser = n => int.Parse(n);
        Func<int, int, bool> predicate = (n,x) => n % x != 0;

        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .ToArray();

        int n = parser(Console.ReadLine());

        numbers = numbers
            .Where(x => predicate(x,n))
            .Reverse()
            .ToArray();

        Console.WriteLine(string.Join(' ', numbers));

    }
}