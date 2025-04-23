namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName 
        {
            get {  return firstName; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.FirstName)} cannot be null or white space!");
                }

                this.firstName = value;

            } 

        }

        public string LastName 
        {
            get { return this.lastName; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.LastName)} cannot be null or white space!");
                }

                this.lastName = value;

            }

        }

        public int Age 
        {
            get { return this.age; } 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Age)} cannot be les than zero!");
                }

                this.age = value;
            } 

        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
