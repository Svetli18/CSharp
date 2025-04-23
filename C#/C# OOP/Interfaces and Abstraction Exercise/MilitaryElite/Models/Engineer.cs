namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => 
            (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repaer in this.Repairs)
            {
                sb.AppendLine($"  {repaer.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
