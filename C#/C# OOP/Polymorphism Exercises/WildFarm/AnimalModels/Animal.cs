namespace WildFarm.AnimalModels
{
    using WildFarm.Caontracts;

    public abstract class Animal : IAnimal
    {
        private string name;

        private double weight;

        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name 
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{this.Name.GetType().Name} cannot be null ot white space!");
                }

                this.name = value; 
            }
        }

        public double Weight 
        {
            get { return this.weight; } 
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.Weight.GetType().Name} cannot ne negative!");
                }

                this.weight = value;
            } 
        }

        public int FoodEaten 
        {
            get { return this.foodEaten; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.FoodEaten.GetType().Name} cannot ne negative!");
                }

                this.foodEaten = value;
            }
        }

        public abstract void Feed(IFood food);

        public abstract string ProduceSound();

        public abstract override string ToString();
    }
}
