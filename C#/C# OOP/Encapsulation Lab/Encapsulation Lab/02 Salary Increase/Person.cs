namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string name;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be null or white space!");
                } 

                this.name = value;

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
                    throw new ArgumentException($"{nameof(this.Age)} cannot be less than zero!");
                }

                this.age = value;

            }

        }

        public decimal Salary
        {
            get { return this.salary; }
            private set 
            { 
                if (value < 0) 
                {
                    throw new ArgumentException($"{nameof(this.Salary)} cannot be negative!");
                } 

                this.salary = value;

            }

        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage = percentage / 2;
            }

            this.Salary *= (percentage / 100) + 1; 

        }

        public override string ToString()
        {
            return $"{this.Name} {this.LastName} receives {this.Salary:F2} leva.";
        }

    }
}
