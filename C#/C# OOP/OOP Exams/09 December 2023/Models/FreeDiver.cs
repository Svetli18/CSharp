namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int OXYGEN_LEVEL = 120;

        public FreeDiver(string name)
            :base(name, OXYGEN_LEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            base.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.60m, MidpointRounding.AwayFromZero);

            if (base.OxygenLevel < 0)
            {
                base.OxygenLevel = 0;
            }
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = OXYGEN_LEVEL;
        }
    }
}
