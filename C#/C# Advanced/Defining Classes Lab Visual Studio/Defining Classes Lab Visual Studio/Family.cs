namespace DefiningClasses
{
    using System.Linq;
    using System.Collections.Generic;

    public class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = members
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestMember;
        }

        public List<Person> GetMembersMoreThan30()
        {
            List<Person> sortedMembers = members
                .Where(m => m.Age > 30)
                .OrderBy(m => m.Name)
                .ToList();

            return sortedMembers;

        }

    }
}
