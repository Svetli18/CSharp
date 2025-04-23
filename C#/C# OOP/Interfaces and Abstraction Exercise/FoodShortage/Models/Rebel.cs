namespace FoodShortage.Models
{
    using FoodShortage.Contracts;

    public class Rebel : Person, IRebel
    {
        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; }

        public int Food {  get; private set; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
