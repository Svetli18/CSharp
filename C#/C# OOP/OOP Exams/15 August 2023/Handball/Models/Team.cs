namespace Handball.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Handball.Models.Contracts;
    using Handball.Utilities.Messages;
    using System.Text;

    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private ICollection<IPlayer> players;

        private Team()
        {
            this.players = new List<IPlayer>();
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
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                this.name = value;
            }
        }

        public int PointsEarned 
        {
            get { return this.pointsEarned; }
            private set { this.pointsEarned = value; }
        }

        public double OverallRating =>
            double.Parse($"{this.Players.Sum(p => p.Rating) / this.Players.Count:F2}");

        public IReadOnlyCollection<IPlayer> Players => 
            (IReadOnlyCollection<IPlayer>)this.players;

        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }

        public void Win()
        {
            this.PointsEarned += 3;

            foreach (var player in this.players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in this.players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            this.PointsEarned += 1;

            foreach (var player in this.players)
            {
                if (player.GetType().Name == "Goalkeeper")
                {
                    player.IncreaseRating();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            double overallRatingResult = this.OverallRating;
            if (double.NaN == this.OverallRating)
            {
                overallRatingResult = 0;
            }

            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");

            if (0 < this.Players.Count)
            {
                sb.AppendLine($"--Overall rating: {overallRatingResult}");
                sb.Append("--Players: ");
                int cnt = 0;
                foreach (var player in this.players)
                {
                    if (cnt == 0)
                    {
                        sb.Append(player.Name);
                        cnt++;
                        continue;
                    }

                    sb.Append($", {player.Name}");
                }
            }
            else
            {
                sb.AppendLine($"--Overall rating: {0}");
                sb.Append("--Players: ");
                sb.Append("none");
            }

            sb.AppendLine();

            return sb.ToString().TrimEnd();
        }
    }
}
