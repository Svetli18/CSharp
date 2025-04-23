using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Action<string[]> action = names 
            => Console.WriteLine(string.Join(Environment.NewLine, names));

        var names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        action(names);
    }
}