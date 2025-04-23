using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var arr = Console.ReadLine()
            .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);


        var func = new Func<string[], int[]>(arr => arr.Select(n => int.Parse(n)).ToArray());

        int[] numbs = func(arr);

        var count = numbs.Length;

        var sum = numbs.Sum();

        Console.WriteLine(count);
        Console.WriteLine(sum);
    }
}