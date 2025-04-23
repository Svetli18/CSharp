using System;
using System.Linq;
using System.Collections.Generic;

class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name} with ID: {Id} is {Age} years old.";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> list = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] currentPerson = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = currentPerson[0];
            string id = currentPerson[1];
            int age = int.Parse(currentPerson[2]);

            Person person = new Person(name, id, age);

            list.Add(person);
        }

        list.OrderBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p));

    }
}