namespace PersonsInfo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            Team team = new Team("SoftUni");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = personArgs[0];
                    string lastName = personArgs[1];
                    int age = int.Parse(personArgs[2]);
                    decimal salary = decimal.Parse(personArgs[3]);

                    Person person = new Person(name, lastName, age, salary);
                    person.IncreaseSalary(20);

                    people.Add(person);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            foreach (var person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}