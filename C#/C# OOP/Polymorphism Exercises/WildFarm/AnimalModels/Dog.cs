using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public class Dog : Mammal
    {
        private ICollection<IFood> dogManu;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.dogManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Meat": this.dogManu.Add(food);
                    break;
                default: throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.40);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
