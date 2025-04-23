namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int MIN_GRAMS = 1; 
        private const int MAX_GRAMS = 200; 

        private string flourType;

        private string bakingTechnique;

        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType 
        { 
            get {  return this.flourType; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            } 
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public int Grams
        {
            get { return this.grams; }
            private set
            {
                if (value < MIN_GRAMS || MAX_GRAMS < value)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        public double FlourTypeModifier()
        {
            switch (this.FlourType)
            {
                case "White": return 1.5;
                case "Wholegrain": return 1;
                default: throw new Exception("Invalid type of dough.");
            }
        }

        public double BakingTechniqueModifier()
        {
            switch (this.BakingTechnique)
            {
                case "Crispy": return 0.9;
                case "Chewy": return 1.1;
                case "Homemade": return 1.0;
                default: throw new Exception("Invalid type of dough.");
            }
        }

        public double Calculator()
        {
            return (2 * this.Grams) * this.FlourTypeModifier() * this.BakingTechniqueModifier();
        }
    }
}
