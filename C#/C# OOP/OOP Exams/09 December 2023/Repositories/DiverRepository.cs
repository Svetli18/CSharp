namespace NauticalCatchChallenge.Repositories
{
    using System.Collections.Generic;

    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories.Contracts;

    public class DiverRepository : IRepository<IDiver>
    {
        private ICollection<IDiver> models;

        public DiverRepository()
        {
            this.models = new HashSet<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models => 
            (IReadOnlyCollection<IDiver>)this.models;

        public void AddModel(IDiver model)
        {
            this.models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return this.models.FirstOrDefault(d => d.Name == name);
        }
    }
}
