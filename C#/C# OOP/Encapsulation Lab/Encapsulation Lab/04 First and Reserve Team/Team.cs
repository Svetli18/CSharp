namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        private string name;

        private List<Person> firstTeam;

        private List<Person> reserveTeam;

        private Team()
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public Team(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name 
        {
            get { return this.name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannotbe null or white space!");
                }

                this.name = value;

            }
        }

        public IReadOnlyList<Person> FirstTeam => this.firstTeam.AsReadOnly();

        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
