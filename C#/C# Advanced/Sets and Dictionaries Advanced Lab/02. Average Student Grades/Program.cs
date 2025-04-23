using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var students = new Dictionary<string, List<decimal>>();

        for (int i = 0; i < n; i++)
        {
            var current = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = current[0];
            var grade = decimal.Parse(current[1]);

            if (!students.ContainsKey(name))
            {
                students[name] = new List<decimal>();
            }

            students[name].Add(grade);

        }

        foreach (var student in students)
        {
            Console.Write($"{student.Key} -> ");

            foreach (var studentGrades in student.Value)
            {
                Console.Write($"{studentGrades:F2} ");
            }

            Console.WriteLine($"(avg: {student.Value.Sum() / student.Value.Count:F2})");

        }

    }
}