namespace PlayersAndMonsters
{
    using System;

    public class Hero
    {
        private string username;

        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username 
        {
            get => this.username; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or white space!!!");
                }

                this.username = value;
            } 
        }

        public int Level 
        {
            get => this.level;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Level cannot be negative!!!");
                }

                this.level = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
