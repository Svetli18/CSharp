namespace HighwayToPeak.Models
{
    using System.Collections.Generic;

    using HighwayToPeak.Models.Contracts;

    public class BaseCamp : IBaseCamp
    {
        private ICollection<string> residents;

        public BaseCamp()
        {
            this.residents = new SortedSet<string>();
        }

        public IReadOnlyCollection<string> Residents 
            => (IReadOnlyCollection<string>)this.residents;

        public void ArriveAtCamp(string climberName)
        {
            this.residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            this.residents.Remove(climberName);
        }
    }
}
