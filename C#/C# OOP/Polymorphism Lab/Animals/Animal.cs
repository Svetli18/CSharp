namespace Animals
{
    using System;

    using Animals.Contracts;

    public abstract class Animal : IAnimal
    {
        private string name;

        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name 
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(this.Name)} cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public string FavouriteFood
        {
            get { return this.favouriteFood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(this.FavouriteFood)} cannot be null or white space!");
                }

                this.favouriteFood = value;
            }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}" ;
        }
    }
}
