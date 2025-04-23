namespace Guild
{
    using System.Text;

    public class Player
    {
        private Player()
        {
            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public Player(string name, string clas)
            :this()
        {
            this.Name = name;
            this.Class = clas;
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
