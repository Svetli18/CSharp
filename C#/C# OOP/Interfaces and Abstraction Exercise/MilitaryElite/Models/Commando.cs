namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using MilitaryElite.Contracts;
    using MilitaryElite.Enumarations;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            if (mission.State == State.inProgress)
            {
                this.missions.Add(mission);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
