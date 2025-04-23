using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<int[], int> func = numbers
            =>
        {
            var minNumber = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        };

        var numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(func(numbers));
    }
}