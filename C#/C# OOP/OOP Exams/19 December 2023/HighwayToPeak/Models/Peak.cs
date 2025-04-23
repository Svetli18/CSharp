namespace HighwayToPeak.Models
{
    using System;

    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Utilities.Messages;

    public class Peak : IPeak
    {
        private string name;
        private int elevation;
        private string difficultyLevel;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            this.Name = name;
            this.Elevation = elevation;
            this.DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public int Elevation
        {
            get { return this.elevation; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }

                this.elevation = value;
            }
        }

        public string DifficultyLevel 
        {
            get { return this.difficultyLevel; }
            private set { this.difficultyLevel = value; }
        }

        public override string ToString()
        {
            return $"Peak: {this.Name} -> Elevation: {this.Elevation}, Difficulty: {this.DifficultyLevel}";
        }
    }
}
