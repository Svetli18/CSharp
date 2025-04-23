namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pizza
    {
        private const int MIN_TOPPINGS_COUNT = 0;
        private const int MAX_TOPPINGS_COUNT = 10;
        private const int MIN_NAME_LENGTH = 1;
        private const int MAX_NAME_LENGTH = 15;

        private string name;

        private List<Topping> toppings;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name 
        {
            get { return this.name; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || 
                    MAX_NAME_LENGTH < value.Length)
                {
                    throw new Exception($"Pizza {this.Name} should be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH} symbols.");
                }

                this.name = value;
            } 
        }

        public Dough Dough { get; set; }

        public int NumberOfToppings { get { return this.toppings.Count; } }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings == MAX_TOPPINGS_COUNT)
            {
                throw new Exception($"Number of toppings should be in range [{MIN_TOPPINGS_COUNT}..{MAX_TOPPINGS_COUNT}].");
            }

            this.toppings.Add(topping);

        }

        public double PizzaTotalCalories()
        {
            double totalCalories = this.Dough.Calculator();

            foreach (var topping in this.toppings)
            {
                totalCalories += topping.Calculator();
            }

            return totalCalories;
        }
    }
}
