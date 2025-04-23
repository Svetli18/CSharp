using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public class Cat : Feline
    {
        private ICollection<IFood> catManu;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.catManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Meat": this.catManu.Add(food);
                    break;
                case "Vegetable": this.catManu.Add(food);
                    break;
                default: throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.30);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
