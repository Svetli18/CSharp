using System;
using System.Linq;
using System.Collections.Generic;

class Student
{
    public Student(string firstName, string lastName, int age, string homeTown)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        HomeTown = homeTown;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Student> list = new List<Student>();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] currentStudent = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string furstName = currentStudent[0];
            string lastName = currentStudent[1];
            int age = int.Parse(currentStudent[2]);
            string homeTown = currentStudent[3];

            if (IsStudentExist(list, furstName, lastName))
            {
                int index = GetStudentIndex(list, furstName, lastName);

                list[index].Age = age;
                list[index].HomeTown = homeTown;
                continue;
            }

            list.Add(new Student(furstName, lastName, age, homeTown));
        }

        string town = Console.ReadLine();

        list.Where(s => s.HomeTown.Equals(town))
            .ToList()
            .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} is {s.Age} years old."));
    }

    static int GetStudentIndex(List<Student> list, string furstName, string lastName)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].FirstName.Equals(furstName) && list[i].LastName.Equals(lastName))
            {
                return i;
            }
        }

        return -1;
    }

    static bool IsStudentExist(List<Student> list, string furstName, string lastName)
    {
        foreach (var student in list)
        {
            if (student.FirstName.Equals(furstName) && student.LastName.Equals(lastName))
            {
                return true;
            }
        }

        return false;
    }
}