namespace Border.Models
{
    using Border.Contracts;

    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }
    }
}