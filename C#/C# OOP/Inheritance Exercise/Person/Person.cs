namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private const int MinPersonAge = 0;

        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        { 
            get => this.name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!!!");
                }

                this.name = value;
            } 
        }

        public virtual int Age 
        { 
            get => this.age; 
            protected set
            {
                if (value < MinPersonAge)
                {
                    throw new ArgumentException("Person cannot have negative age!!!");                   
                }

                this.age = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString().TrimEnd();
        }
    }
}
