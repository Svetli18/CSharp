namespace NauticalCatchChallenge.Core
{
    using NauticalCatchChallenge.Core.Contracts;
    using NauticalCatchChallenge.Models;
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories;
    using NauticalCatchChallenge.Utilities.Messages;
    using System.Text;

    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishes;

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishes = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver = null;

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if(diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            IDiver existDiver = this.divers.GetModel(diverName);

            if (existDiver != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, this.divers.GetType().Name);
            }

            this.divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, this.divers.GetType().Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish = null;

            if(fishType == "ReefFish")
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            IFish existFish = this.fishes.GetModel(fishName);

            if (existFish != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, this.fishes.GetType().Name);
            }

            this.fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = this.divers.GetModel(diverName);

            if(diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, this.divers.GetType().Name, diverName);
            }

            IFish fish = this.fishes.GetModel(fishName);

            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                TestDiverOxygenLevelIsOk(diver);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    TestDiverOxygenLevelIsOk(diver);
                    return string.Format(OutputMessages.DiverHitsFish, diver.Name, fish.Points, fish.Name);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    TestDiverOxygenLevelIsOk(diver);
                    return string.Format(OutputMessages.DiverMisses, diver.Name, fish.Name);
                }
            }

            diver.Hit(fish);
            TestDiverOxygenLevelIsOk(diver);
            return string.Format(OutputMessages.DiverHitsFish, diver.Name, fish.Points, fish.Name);
        }

        public string HealthRecovery()
        {
            int cnt = 0;

            foreach (var diver in this.divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    cnt++;
                }
            }

            return string.Format(OutputMessages.DiversRecovered, cnt);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = this.divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var fishName in diver.Catch)
            {
                IFish fish = this.fishes.GetModel(fishName);

                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            ICollection<IDiver> healtyDivers = new List<IDiver>();

            foreach (var diver in this.divers.Models)
            {
                if (!diver.HasHealthIssues)
                {
                    healtyDivers.Add(diver);
                }
            }

            ICollection<IDiver> sortedDivers = 
                healtyDivers
                .OrderByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var currDiver in sortedDivers)
            {
                sb.AppendLine(currDiver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static void TestDiverOxygenLevelIsOk(IDiver diver)
        {
            if (diver.OxygenLevel <= 0)
            {//TODO moje da se naloji da zanulim na gmurkacha nevoto na kislorod!!
                diver.UpdateHealthStatus();
            }
        }
    }
}
