namespace PersonsInfo
{
    public class Person
    {
        private string first;

        private string last;

        private int age;

        private decimal salary;

        public Person(string first, string last, int age, decimal salary)
        {
            this.First = first;
            this.Last = last;
            this.Age = age;
            this.Salary = salary;
        }

        public string First
        {
            get { return this.first; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"{nameof(this.First)} name cannot contain fewer than 3 symbols!");
                }

                this.first = value;

            }

        }

        public string Last
        {
            get { return this.last; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"{nameof(this.Last)} name cannot contain fewer than 3 symbols!");
                }

                this.last = value;

            }

        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"{nameof(this.Age)} cannot be zero or a negative integer!");
                }

                this.age = value;

            }

        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException($"{nameof(this.Salary)} cannot be less than 650 leva!");
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
            return $"{this.First} {this.Last} receives {this.Salary:F2} leva.";
        }
    }
}
