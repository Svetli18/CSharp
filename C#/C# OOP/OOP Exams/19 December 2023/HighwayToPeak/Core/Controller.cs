namespace HighwayToPeak.Core
{
    using System;
    using System.Text;
    using HighwayToPeak.Core.Contracts;
    using HighwayToPeak.Models;
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories;
    using HighwayToPeak.Utilities.Messages;

    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }
        //ok
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak peak = this.peaks.Get(name);

            if (peak != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel == "Extreme" || difficultyLevel == "Hard" || difficultyLevel == "Moderate")
            {
                peak = new Peak(name, elevation, difficultyLevel);
                this.peaks.Add(peak);

                return string.Format(OutputMessages.PeakIsAllowed, name, this.peaks.GetType().Name);
            }
            else
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
        }
        //ok
        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = this.climbers.Get(climberName);

            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            IPeak peak = this.peaks.Get(peakName);

            if (peak == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!this.baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            if (climber.GetType().Name == "NaturalClimber" &&
                peak.DifficultyLevel == "Extreme")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            this.baseCamp.LeaveCamp(climber.Name);
            climber.Climb(peak);

            if (climber.Stamina <= 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            else
            {
                this.baseCamp.ArriveAtCamp(climber.Name);
                return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
            }
        }
        //ok
        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();

            if (0 < this.baseCamp.Residents.Count)
            {
                sb.AppendLine("BaseCamp residents:");

                foreach (var currentClimberName in this.baseCamp.Residents)
                {
                    IClimber climber = this.climbers.Get(currentClimberName);
                    sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
                }
            }
            else
            {
                sb.AppendLine("BaseCamp is currently empty.");
            }

            return sb.ToString().TrimEnd();
        }
        //ok
        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!this.baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = this.climbers.Get(climberName);
            int cnt = daysToRecover;

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climber.Name);
            }

            while (true)
            {

                climber.Rest(daysToRecover);
                cnt--;

                if (climber.Stamina == 10 || cnt == 0)
                {
                    return string.Format(OutputMessages.ClimberRecovered, climber.Name, daysToRecover);
                }
            }
        }
        //ok
        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climber = this.climbers.Get(name);

            if (climber != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, this.climbers.GetType().Name);
            }

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            this.climbers.Add(climber);
            this.baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }
        //ok
        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");

            ICollection<IClimber> sortedClimbers =
                this.climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var currClimber in sortedClimbers)
            {
                ICollection<IPeak> currPeaks = new List<IPeak>();

                foreach (var currPeakName in currClimber.ConqueredPeaks)
                {
                    IPeak currPeak = this.peaks.Get(currPeakName);
                    currPeaks.Add(currPeak);
                }

                sb.AppendLine(currClimber.ToString());

                ICollection<IPeak> sortedPeaks =
                    currPeaks.OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (var peak in sortedPeaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
