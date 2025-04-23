namespace NauticalCatchChallenge.Models
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;
    using System.Collections.Generic;

    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private ICollection<string> @catch;
        private bool hasHealthIssues;

        private Diver()
        {
            this.@catch = new List<string>();
        }

        public Diver(string name, int oxygenLevel)
            :this()
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get => this.oxygenLevel;
            protected set => this.oxygenLevel = value;
        }

        public IReadOnlyCollection<string> Catch =>
            (IReadOnlyCollection<string>)this.@catch;

        public double CompetitionPoints { get; protected set; }

        public bool HasHealthIssues => this.hasHealthIssues;

        public void Hit(IFish fish)
        {
            if (fish != null)
            {
                this.oxygenLevel -= fish.TimeToCatch;
                this.@catch.Add(fish.Name);
                this.CompetitionPoints += fish.Points;

                if (this.OxygenLevel < 0)
                {
                    this.oxygenLevel = 0;
                }
            }
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (this.hasHealthIssues)
            {
                this.hasHealthIssues = false;
            }
            else
            {
                this.hasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {this.CompetitionPoints:F1} ]";
        }
    }
}
