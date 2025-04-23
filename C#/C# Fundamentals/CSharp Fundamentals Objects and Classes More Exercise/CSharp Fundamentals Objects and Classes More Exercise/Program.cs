using System;
using System.Linq;
using System.Collections.Generic;

class Employee
{
    public Employee(string name, decimal salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }

    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> list = new List<Employee>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentEmployee = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = currentEmployee[0];
            decimal salary = decimal.Parse(currentEmployee[1]);
            string department = currentEmployee[2];

            Employee employee = new Employee(name, salary, department);
            list.Add(employee);

        }

        string sortedDepartment = "";
        decimal bestAverigeSalarys = 0;

        for (int i = 0; i < list.Count; i++)
        {
            string currentDepartment = list[i].Department;
            decimal currentSalary = list[i].Salary;

            for (int j = i + 1; j < list.Count; j++)
            {
                if (currentDepartment == list[j].Department)
                {
                    currentSalary += list[j].Salary;
                }
            }

            if (bestAverigeSalarys < currentSalary)
            {
                sortedDepartment = currentDepartment;
                bestAverigeSalarys = currentSalary;
            }
        }

        Console.WriteLine($"Highest Average Salary: {sortedDepartment}");
        list.Where(e => e.Department.Equals(sortedDepartment))
            .OrderByDescending(e => e.Salary)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.Name} {e.Salary:F2}"));
    }
}