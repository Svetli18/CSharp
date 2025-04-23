namespace Guild
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Guild
    {
        private List<Player> roster;

        private Guild()
        {
            this.roster = new List<Player>();
        }

        public Guild(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            return this.roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }

        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] removedPlayers = this.roster.Where(p => p.Class == clas).ToArray();

            this.roster.RemoveAll(p => p.Class == clas);

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            sb.AppendLine(string.Join(Environment.NewLine, this.roster));

            return sb.ToString().TrimEnd();
        }
    }
}
