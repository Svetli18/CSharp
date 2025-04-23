namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private List<Product> bag;

        private string name;

        private decimal money;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(this.Name)} cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception($"{nameof(this.Money)} cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> BagOfProducts => this.bag.AsReadOnly();

        public void AddProduct(Product product)
        {
            this.Money -= product.Cost;
            this.bag.Add(product);
        }
    }
}
