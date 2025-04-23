namespace WildFarm.AnimalModels
{
    using System;
    using WildFarm.Caontracts;

    public class Owl : Bird
    {
        private ICollection<IFood> owlManu;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.owlManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Meat": this.owlManu.Add(food);
                    break;
                default: throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.25);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
