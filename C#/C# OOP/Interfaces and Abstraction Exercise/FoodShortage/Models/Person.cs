namespace FoodShortage.Models
{
    using FoodShortage.Contracts;

    public abstract class Person : IPerson
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int Food { get; private set; }

        public abstract void BuyFood();
    }
}
