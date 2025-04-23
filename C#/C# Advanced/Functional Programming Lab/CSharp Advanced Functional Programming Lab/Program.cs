using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var arr = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .Where(numbs => numbs % 2 == 0)
            .OrderBy(n => n)
            .ToArray();

        var print = new Action<int[]>(arr => );
    }
}