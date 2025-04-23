namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => this.name; }

        public int Age { get => this.age; }

        public int CompareTo([AllowNull] Person otherPerson)
        {
            int result = 1;

            if (otherPerson != null)
            {
                result = this.Name.CompareTo(otherPerson.Name);

                if (result == 0)
                {
                    result = this.Age.CompareTo(otherPerson.Age);
                }
            }

            return result;

        }

        public override bool Equals(object obj)
        {
            if (obj is Person otherPerson)
            {
                return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
