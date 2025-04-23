using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] text = Console.ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries);

        text.Where(w => w.Length % 2 == 0)
            .ToList()
            .ForEach(w => Console.WriteLine(w));
    }
}