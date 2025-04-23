namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private const int MIN = 0;
        private const int MAX = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance 
        { 
            get { return this.endurance; } 
            private set
            {
                if (value < MIN || MAX < value)
                {
                    throw new Exception($"{nameof(this.Endurance)} should be between {MIN} and {MAX}.");
                }

                this.endurance = value;
            } 
        }

        public int Sprint 
        { 
            get { return this.sprint; }
            private set
            {
                if (value < MIN || MAX < value)
                {
                    throw new Exception($"{nameof(this.Sprint)} should be between {MIN} and {MAX}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble 
        { 
            get { return this.dribble; }
            private set
            {
                if (value < MIN || MAX < value)
                {
                    throw new Exception($"{nameof(this.Dribble)} should be between {MIN} and {MAX}.");
                }

                this.dribble = value;
            }
        }

        public int Passing 
        { 
            get { return this.passing; }
            private set
            {
                if (value < MIN || MAX < value)
                {
                    throw new Exception($"{nameof(this.Passing)} should be between {MIN} and {MAX}.");
                }

                this.passing = value;
            }
        }

        public int Shooting 
        { 
            get { return this.shooting; }
            private set
            {
                if (value < MIN || MAX < value)
                {
                    throw new Exception($"{nameof(this.Shooting)} should be between {MIN} and {MAX}.");
                }

                this.shooting = value;
            }
        }

        public int PlayerStats()
        {
            return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
        }
    }
}
