namespace Birthday.Models
{
    using System;

    using Birthday.Contracts;

    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, DateTime dateTime)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.DateTime = dateTime;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public DateTime DateTime { get; }
    }
}
