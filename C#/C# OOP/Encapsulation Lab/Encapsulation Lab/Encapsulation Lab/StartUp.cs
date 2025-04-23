namespace PersonsInfo
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = personArgs[0];
                string lastName = null;
                int age = int.Parse(personArgs[2]);

                Person person = new Person(firstName, lastName, age);

                people.Add(person);

            }

            people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p));
        }
    }
}