using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        private const double INITIAL_RATING_VALUE = 4;

        public CenterBack(string name) 
            : base(name, INITIAL_RATING_VALUE)
        {
        }

        public override void IncreaseRating()
        {
            if (10 < base.Rating + 1)
            {
                base.Rating = 10;
            }
            else
            {
                base.Rating += 1;
            }
        }

        public override void DecreaseRating()
        {
            if (base.Rating - 1 < 1)
            {
                base.Rating = 1;
            }
            else
            {
                base.Rating -= 1;
            }
        }
    }
}
