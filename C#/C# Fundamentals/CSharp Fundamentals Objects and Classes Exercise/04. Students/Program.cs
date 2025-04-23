using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName  { get; set; }
        public string LastName  { get; set; }
        public double Grade  { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            string[] currentStudent = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName  = currentStudent[0];
            string lastName  = currentStudent[1];
            double grade  = double.Parse(currentStudent[2]);

            Student student = new Student(firstName, lastName, grade);
            students.Add(student);
        }

        students.OrderByDescending(s => s.Grade)
            .ToList()
            .ForEach(s => Console.WriteLine(s));
    }
}