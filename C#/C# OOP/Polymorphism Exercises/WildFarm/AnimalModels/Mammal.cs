using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return this.livingRegion; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{this.LivingRegion.GetType().Name} cannot be null or white space!");
                }

                this.livingRegion = value;
            }
        }
    }
}
