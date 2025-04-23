namespace HighwayToPeak.Models
{
    using System.Text;
    using System.Collections.Generic;

    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Utilities.Messages;

    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        protected ICollection<string> conqueredPeaks;

        private Climber()
        {
            conqueredPeaks = new List<string>();
        }

        protected Climber(string name, int stamina)
            :this()
        {
            this.Name = name;
            this.Stamina = stamina;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }

                this.name = value; 
            }
        }



        public int Stamina
        {
            get { return this.stamina; }
            protected set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (10 < value)
                {
                    value = 10;
                }

                this.stamina = value; 
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => (IReadOnlyCollection<string>)this.conqueredPeaks;

        public virtual void Climb(IPeak peak)
        {
            string currName = this.conqueredPeaks.FirstOrDefault(p => p.Equals(peak.Name));

            if (currName == null)
            {
                this.conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                this.Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                this.Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                this.Stamina -= 2;
            }

        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {this.Name}, Stamina: {this.Stamina}");

            if (0 < this.ConqueredPeaks.Count)
            {
                sb.AppendLine($"Peaks conquered: {this.ConqueredPeaks.Count}");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
