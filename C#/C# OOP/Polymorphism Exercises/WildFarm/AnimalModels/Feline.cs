using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{this.Breed.GetType().Name} cannot be null or white space!");
                }

                this.breed = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
