using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var prse = int.TryParse(Console.ReadLine(), out int n);

        var numbs = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            var tryPars = int.TryParse(Console.ReadLine(), out int curr);

            if (!numbs.ContainsKey(curr))
            {
                numbs[curr] = 0;
            }

            numbs[curr]++;
        }

        numbs.Where(n => n.Value % 2 == 0).ToList().ForEach(n => Console.WriteLine(n.Key));
    }
}