namespace Birthday.Models
{
    using Birthday.Contracts;

    public class Robot : IRobot
    {
        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; }

        public string Id { get; }
    }
}
