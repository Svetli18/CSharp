namespace HighwayToPeak.Repositories
{
    using System.Collections.Generic;

    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories.Contracts;

    public class ClimberRepository : IRepository<IClimber>
    {
        private ICollection<IClimber> all;

        public ClimberRepository()
        {
            this.all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All 
            => (IReadOnlyCollection<IClimber>)this.all;

        public void Add(IClimber model)
        {
            this.all.Add(model);
        }

        public IClimber Get(string name)
        {
            return this.all.FirstOrDefault(c => c.Name == name);
        }
    }
}
