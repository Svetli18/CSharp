namespace Birthday.Models
{
    using System;

    using Birthday.Contracts;

    public class Pet : IPet
    {
        public Pet(string name, DateTime dateTime)
        {
            this.Name = name;
            this.DateTime = dateTime;
        }

        public string Name { get; }

        public DateTime DateTime { get; }
    }
}
