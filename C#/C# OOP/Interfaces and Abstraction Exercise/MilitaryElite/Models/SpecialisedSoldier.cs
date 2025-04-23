namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumarations;
    using System.Text;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string strCorps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = CorpsTryParse(strCorps);
        }

        public Corps Corps { get; protected set; }

        private Corps CorpsTryParse(string strCorps)
        {
            Corps corps;
            bool parsed = Enum.TryParse(strCorps, out corps);

            if (!parsed)
            {
                throw new Exception("Invalid Corps!!!");
            }

            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}
