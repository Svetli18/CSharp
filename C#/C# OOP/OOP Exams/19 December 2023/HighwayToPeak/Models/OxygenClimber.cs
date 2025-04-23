namespace HighwayToPeak.Models
{

    public class OxygenClimber : Climber
    {
        private const int INITIAL_STAMINA = 10;

        public OxygenClimber(string name)
            :base(name, INITIAL_STAMINA)
        {
            
        }

        public override void Rest(int daysCount)
        {
            base.Stamina += 1;
        }
    }
}
