namespace CocktailParty
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Cocktail
    {
        public List<Ingredient> Ingredients;

        private Cocktail()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
            :this()
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Count;

        public void Add(Ingredient ingredient)
        {
            Ingredient test = this.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
            //moje da se naloji dopulnitelna dobavka kum if proverkata!!!!
            if (test == null  && 
                this.Ingredients.Count < this.Capacity && 
                ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = this.Ingredients.FirstOrDefault(i => i.Name == name);

            return this.Ingredients.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = this.Ingredients.FirstOrDefault(i => i.Name == name);

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = this.Ingredients
                .OrderByDescending(i => i.Alcohol)
                .FirstOrDefault();

            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var item in this.Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }
    }
}
