using WildFarm.Caontracts;

namespace WildFarm.AnimalModels
{
    public class Hen : Bird
    {
        private ICollection<IFood> henManu;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.henManu = new List<IFood>();
        }

        public override void Feed(IFood food)
        {
            switch (food.GetType().Name)
            {
                case "Meat": this.henManu.Add(food);
                    break;
                case "Fruit": this.henManu.Add(food);
                    break;
                case "Seeds": this.henManu.Add(food);
                    break;
                case "Vegetable": this.henManu.Add(food);
                    break;
            }

            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.35);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
