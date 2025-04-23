namespace DefiningClasses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestMember;
        }
    }
}
