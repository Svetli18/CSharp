namespace ValidationAttributes.Models
{
    using System;
    using ValidationAttributes.Attributes;

    public class Person
    {

        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; set; }

        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; set; }
    }
}
