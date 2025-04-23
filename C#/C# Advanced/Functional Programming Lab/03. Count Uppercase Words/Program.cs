using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var words = Console.ReadLine()
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var func = new Func<string, bool>(w => char.IsUpper(w[0]));

        foreach (var word in words)
        {
            if (func(word))
            {
                Console.WriteLine(word);
            }
        }
    }
}