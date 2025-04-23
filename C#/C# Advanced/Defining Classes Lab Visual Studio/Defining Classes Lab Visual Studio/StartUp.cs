namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            bool parse = int.TryParse(Console.ReadLine(), out int n);
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] memberArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = memberArgs[0];
                bool tryParse = int.TryParse(memberArgs[1], out int age);

                Person member = new Person(name, age);

                family.AddMember(member);

            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
