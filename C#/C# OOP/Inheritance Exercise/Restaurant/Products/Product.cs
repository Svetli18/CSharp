namespace Restaurant.Products
{
    using System;

    public class Product
    {
        private string name;

        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get {  return this.name; }
            protected set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!!!");
                }

                this.name = value;
            } 
        }

        public decimal Price 
        {
            get { return this.price; } 
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!!!");
                }

                this.price = value;
            }
        }
    }
}
