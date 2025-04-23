namespace WildFarm.FoodModels
{
    using WildFarm.Caontracts;

    public class Meat : IFood
    {
        private int quantity;

        public Meat(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.GetType().Name} cannot be negative!");
                }

                this.quantity = value;
            }
        }
    }
}
