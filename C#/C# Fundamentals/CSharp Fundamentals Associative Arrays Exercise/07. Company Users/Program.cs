using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var itCompanys = new Dictionary<string, List<string>>();

        string cmd;
        while ((cmd = Console.ReadLine()) != "End")
        {
            var cmdArgs = cmd.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            var companyName = cmdArgs[0];
            var employeeId = cmdArgs[1];

            if (!itCompanys.ContainsKey(companyName))
            {
                itCompanys[companyName] = new List<string>();
            }

            if (!itCompanys[companyName].Contains(employeeId))
            {
                itCompanys[companyName].Add(employeeId);
            }
        }

        foreach (var company in itCompanys)
        {
            Console.WriteLine(company.Key);

            foreach (var employee in itCompanys[company.Key])
            {
                Console.WriteLine($"-- {employee}");
            }
        }

    }
}