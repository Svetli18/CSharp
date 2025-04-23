namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int OXYGEN_LEVEL = 540;

        public ScubaDiver(string name)
            : base(name, OXYGEN_LEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            base.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.30m, MidpointRounding.AwayFromZero);

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
