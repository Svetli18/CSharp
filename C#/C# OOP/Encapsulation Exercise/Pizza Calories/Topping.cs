namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 50;

        private string toppingType;
        private int grams;

        public Topping(string toppingType, int grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
        }

        public string ToppingType  
        { 
            get {  return this.toppingType; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            } 
        }

        public int Grams
        {
            get { return this.grams; }
            private set
            {
                if (value < MIN_GRAMS || MAX_GRAMS < value)
                {
                    throw new Exception($"{this.ToppingType} weight should be in the range [{MIN_GRAMS}..{MAX_GRAMS}].");
                }

                this.grams = value;
            }
        }

        public double ToppingTypeModifier()
        {
            switch (this.ToppingType)
            {
                case "Meat": return 1.2;
                case "meat": return 1.2;
                case "Veggies": return 0.8;
                case "veggies": return 0.8;
                case "Cheese": return 1.1;
                case "cheese": return 1.1;
                case "Sauce": return 0.9;
                case "sauce": return 0.9;
                default: throw new Exception($"Cannot place {this.ToppingType} on top of your pizza.");
            }
        }

        public double Calculator()
        {
            return (2 * this.Grams) * this.ToppingTypeModifier();
        }
    }
}
