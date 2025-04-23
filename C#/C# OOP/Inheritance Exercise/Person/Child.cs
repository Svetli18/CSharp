namespace Person
{
    using System;

    public class Child : Person
    {
        private const int MaxChildAge = 15;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            protected set
            {
                if (MaxChildAge < value)
                {
                    throw new ArgumentException("The chaild age cannot be more than 15");
                }

                base.Age = value;
            }
        }
    }
}
