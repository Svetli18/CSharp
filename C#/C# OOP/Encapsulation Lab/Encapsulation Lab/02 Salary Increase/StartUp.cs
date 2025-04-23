namespace PersonsInfo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                string lastName = personArgs[1];
                int age = int.Parse(personArgs[2]);
                decimal salary = decimal.Parse(personArgs[3]);

                Person person = new Person(name, lastName, age, salary);

                people.Add(person);

            }

            var parcentage = decimal.Parse(Console.ReadLine());

            people.ForEach(p => p.IncreaseSalary(parcentage));

            people.ForEach(p => Console.WriteLine(p));

        }
    }
}