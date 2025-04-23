using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Func<string, int> parser = n => int.Parse(n);

        int number = parser(Console.ReadLine());

        Func<int, int, bool> nameValue = (n, x) => n >= x;

        string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var name in names)
        {
            var nameSum = GetSumOfName(name);

            if (nameValue(nameSum, number))
            {
                Console.WriteLine(name);
                break;
            }

        }

    }

    static int GetSumOfName(string s)
    {
        int sum = 0;

        foreach (var c in s)
        {
            sum += c;
        }

        return sum;
    }
}