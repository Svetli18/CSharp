namespace Zoo
{
    using System;

    public class Animal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space");
                }

                this.name = value;
            }
        }
    }
}
