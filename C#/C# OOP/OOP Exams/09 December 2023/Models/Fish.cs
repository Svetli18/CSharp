namespace NauticalCatchChallenge.Models
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;

    public abstract class Fish : IFish
    {
        private string name;
        private double points;

        public Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FishNameNull));
                }

                this.name = value;
            }
        }

        public double Points
        {
            get => this.points;
            private set
            {
                if (value < 1 || 10 < value)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }

                this.points = value;
            }
        }

        public int TimeToCatch { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.name} [ points: {this.points}, time to catch: {this.TimeToCatch} seconds ]";
        }
    }
}
