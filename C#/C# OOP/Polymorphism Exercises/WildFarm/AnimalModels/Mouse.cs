using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public class Mouse : Mammal
    {
        private ICollection<IFood> mouseManu;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.mouseManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Fruit":
                    this.mouseManu.Add(food);
                    break;
                case "Vegetable":
                    this.mouseManu.Add(food);
                    break;
                default: throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.10);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
