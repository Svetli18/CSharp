namespace Handball.Models.Players
{
    using System;

    public class Goalkeeper : Player
    {
        private const double INITIAL_RATING_VALUE = 2.5;

        public Goalkeeper(string name) 
            : base(name, INITIAL_RATING_VALUE)
        {
        }

        public override void IncreaseRating()
        {
            if (10 < base.Rating + 0.75)
            {
                base.Rating = 10;
            }
            else
            {
                base.Rating += 0.75;
            }
        }

        public override void DecreaseRating()
        {
            if (base.Rating - 1.25 < 1)
            {
                base.Rating = 1;
            }
            else
            {
                base.Rating -= 1.25;
            }
        }
    }
}
