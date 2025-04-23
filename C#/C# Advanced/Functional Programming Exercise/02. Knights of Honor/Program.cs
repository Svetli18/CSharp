using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var title = "Sir ";

        Action <string[]> action = names 
        => Console.WriteLine(title + string.Join(Environment.NewLine + title, names));

        var names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        action(names);
        
    }
}