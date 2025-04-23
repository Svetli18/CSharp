namespace Handball.Models.Players
{
    using System;

    public class ForwardWing : Player
    {
        private const double INITIAL_RATING_VALUE = 5.5;

        public ForwardWing(string name) 
            : base(name, INITIAL_RATING_VALUE)
        {
        }

        public override void IncreaseRating()
        {
            if (10 < base.Rating + 1.25)
            {
                base.Rating = 10;
            }
            else
            {
                base.Rating += 1.25;
            }
        }

        public override void DecreaseRating()
        {
            if (base.Rating - 0.75 < 1)
            {
                base.Rating = 1;
            }
            else
            {
                base.Rating -= 0.75;
            }
        }
    }
}
