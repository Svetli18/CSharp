namespace HighwayToPeak.Repositories
{
    using System.Collections.Generic;

    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories.Contracts;

    public class PeakRepository : IRepository<IPeak>
    {
        private ICollection<IPeak> peaks;

        public PeakRepository()
        {
            this.peaks = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All 
            => (IReadOnlyCollection<IPeak>)this.peaks;

        public void Add(IPeak model)
        {
            this.peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return this.peaks.FirstOrDefault(p => p.Name == name);
        }
    }
}
