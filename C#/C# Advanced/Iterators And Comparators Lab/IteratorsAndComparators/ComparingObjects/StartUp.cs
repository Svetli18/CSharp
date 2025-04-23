namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);

                people.Add(person);

            }

            int personIndex = int.Parse(Console.ReadLine());

            Person personToCampare = null;
            int countOfMatches = 1;
            int countOfNotMatches = 0;

            if (0 <= personIndex - 1 && personIndex - 1 < people.Count)
            {
                personToCampare = people[personIndex - 1];

                for (int i = 0; i < people.Count; i++)
                {
                    if (i == personIndex - 1)
                    {
                        continue;
                    }

                    int result = personToCampare.CompareTo(people[i]);

                    if (result == 0)
                    {
                        countOfMatches++;
                        continue;
                    }

                    countOfNotMatches++;
                }
            }
           
            if (1 < countOfMatches)
            {
                Console.WriteLine($"{countOfMatches} {countOfNotMatches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}
