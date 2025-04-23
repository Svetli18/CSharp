using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<int, int> func = null;
        Action<int[]> action = numbers => Console.WriteLine(string.Join(' ', numbers));
        Func<string, int> parser = number => int.Parse(number);

        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .ToArray();

        string current;
        while ((current = Console.ReadLine()) != "end")
        {
            switch (current)
            {
                case "add": func = n => n + 1;
                {
                    numbers = numbers.Select(func).ToArray();
                } 
                    break;
                case "multiply": func = n => n * 2; 
                {
                    numbers = numbers.Select(func).ToArray();
                };
                    break;
                case "subtract": func = n => n - 1;
                {
                    numbers = numbers.Select(func).ToArray();
                }
                    break;
                case "print": action(numbers); 
                    break;
                    
            }

        }

    }
}