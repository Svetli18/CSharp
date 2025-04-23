namespace FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Team
    {
        private string name;

        private List<Player> players = new List<Player>();

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name 
        {
            get { return this.name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            int result = 0;

            foreach (Player p in this.players)
            {
                result += p.PlayerStats();
            }            

            return (int)Math.Round(result / (double)this.players.Count);
        }

        public void Add(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);

            players.Add(player);
        }

        public void Remove(string name)
        {
            Player player = this.players.FirstOrDefault(p => p.Name.Equals(name));

            if (player == null)
            {
                throw new Exception($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(player);
        }
    }
}
