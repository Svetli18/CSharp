namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSe = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];

                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name, age);

                sortedSet.Add(person);
                hashSe.Add(person);

            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSe.Count);

        }
    }
}
