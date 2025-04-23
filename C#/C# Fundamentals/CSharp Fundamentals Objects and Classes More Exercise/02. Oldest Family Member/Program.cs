using System;
using System.Linq;
using System.Collections.Generic;

class Family
{
    public Family()
    {
        family = new List<Person>();
    }
    List<Person> family { get; set; }

    public void AddMember(Person person)
    {
        family.Add(person);
    }

    public Person GetOldestMember()
    {
        List<Person> members = family.OrderByDescending(m => m.Age).ToList();
        return members.FirstOrDefault();
    }

}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Family family = new Family();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentPerson = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);

            Person person = new Person(name, age);
            family.AddMember(person);

        }

        Person OldestMember = family.GetOldestMember();

        Console.WriteLine($"{OldestMember.Name} {OldestMember.Age}");
    }
}