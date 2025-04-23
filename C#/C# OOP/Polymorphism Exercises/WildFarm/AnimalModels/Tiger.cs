namespace WildFarm.AnimalModels
{
    using WildFarm.Caontracts;

    public class Tiger : Feline
    {
        private ICollection<IFood> tigerManu;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.tigerManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Meat":
                    this.tigerManu.Add(food);
                    break;
                default: throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 1.0);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
