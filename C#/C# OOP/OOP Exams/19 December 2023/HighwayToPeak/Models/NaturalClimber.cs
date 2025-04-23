using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int INITIAL_STAMINA = 6;

        public NaturalClimber(string name)
            :base(name, INITIAL_STAMINA)
        {
            
        }

        public override void Climb(IPeak peak)
        {
            string currName = base.conqueredPeaks.FirstOrDefault(p => p.Equals(peak.Name));

            if (currName == null)
            {
                base.conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Hard")
            {
                base.Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                base.Stamina -= 2;
            }
        }

        public override void Rest(int daysCount)
        {
            base.Stamina += 2;
        }
    }
}
