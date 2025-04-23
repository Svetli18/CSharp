namespace Handball.Models.Players
{
    using Handball.Models.Contracts;
    using Handball.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;

        public Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get { return this.rating; }
            protected set { this.rating = value; }
        }

        public string Team { get; private set; }

        public void JoinTeam(string teamName)
        {
            this.Team = teamName;
        }

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
