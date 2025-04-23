namespace Raiding.Models
{
    using Raiding.Contracts;

    public abstract class BaseHero : IBaseHero
    {
        private string name;

        private int power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name 
        {
            get { return this.name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{this.GetType().Name} cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public int Power 
        {
            get { return this.power; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.GetType().Name} cannot be negative number!");
                }

                this.power = value;
            }
        }

        public abstract string CastAbility();
    }
}
