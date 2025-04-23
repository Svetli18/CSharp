using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var softUni = new Dictionary<string, List<double>>();

        for (int i = 0; i < n; i++)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!softUni.ContainsKey(student))
            {
                softUni[student] = new List<double>();
            }

            softUni[student].Add(grade);

        }

        var sortedSoftUni = softUni
            .Where(s => s.Value.Average() >= 4.5);

        foreach (var kvp in sortedSoftUni)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():F2}");
        }
    }
}