namespace FoodShortage.Models
{
    using FoodShortage.Contracts;
    using System;

    public class Citizen : Person, ICitizen
    {
        public Citizen(string name, int age, string id, DateTime dateTime) 
            : base(name, age)
        {
            this.Id = id;
            this.DateTime = dateTime;
        }

        public string Id { get; }

        public DateTime DateTime { get; }

        public int Food { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
