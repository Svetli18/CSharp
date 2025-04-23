namespace WildFarm.FoodModels
{
    using WildFarm.Caontracts;

    public class Fruit : IFood
    {
        private int quantity;

        public Fruit(int quantity)
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
