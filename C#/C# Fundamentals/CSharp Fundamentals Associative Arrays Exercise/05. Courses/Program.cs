using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var softUni = new Dictionary<string, List<string>>();

        string cmd;
        while ((cmd = Console.ReadLine()) != "end")
        {
            string[] cmdArgs = cmd.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            string courseName = cmdArgs[0];
            string studentName = cmdArgs[1];

            if (!softUni.ContainsKey(courseName))
            {
                softUni[courseName] = new List<string>();
            }

            softUni[courseName].Add(studentName);

        }

        foreach (var csp in softUni)
        {
            Console.WriteLine($"{csp.Key}: {csp.Value.Count}");
            foreach (var student in csp.Value)
            {
                Console.WriteLine($"-- {student}");
            }
        }

    }
}