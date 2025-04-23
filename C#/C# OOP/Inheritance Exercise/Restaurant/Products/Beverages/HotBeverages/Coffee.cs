namespace Restaurant.Products.Beverages.HotBeverages
{
    using System;

    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;

        private const decimal CoffeePrice = 3.50m;

        private double caffeine;

        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine 
        {
            get { return this.caffeine; } 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Caffeine cannot be negative!!!");   
                }

                this.caffeine = value;
            } 
        }
    }
}
