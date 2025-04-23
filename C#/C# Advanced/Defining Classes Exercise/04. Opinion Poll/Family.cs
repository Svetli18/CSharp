using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
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
