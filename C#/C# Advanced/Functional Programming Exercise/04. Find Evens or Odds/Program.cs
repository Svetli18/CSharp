using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {

        Func<string, int> parse = number => int.Parse(number);

        int[] fromTo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => parse(x))
            .ToArray();

        string type = Console.ReadLine();

        Predicate<int> predicate = null;

        if (type == "even")
        {
            predicate = x => x % 2 == 0;
        }
        else if (type == "odd")
        {
            predicate = x => x % 2 != 0;
        }

        List<int> numbers = GetListNumbers(fromTo[0], fromTo[1]);
        
        numbers = numbers.Where(x => predicate(x)).ToList();

        Action<List<int>> print = numbs => Console.WriteLine(string.Join(' ', numbs));

        print(numbers);
    }

    private static List<int> GetListNumbers(int v1, int v2)
    {
        var result = new List<int>();

        for (int i = v1; i <= v2; i++)
        {
            result.Add(i);
        }

        return result;
    }
}