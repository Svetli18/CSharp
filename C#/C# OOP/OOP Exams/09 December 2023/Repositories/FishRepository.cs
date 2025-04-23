namespace NauticalCatchChallenge.Repositories
{
    using System.Collections.Generic;

    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories.Contracts;

    public class FishRepository : IRepository<IFish>
    {
        private ICollection<IFish> models;

        public FishRepository()
        {
            this.models = new HashSet<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => 
            (IReadOnlyCollection<IFish>)this.models;
        public void AddModel(IFish model)
        {
            this.models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return this.models.FirstOrDefault(f => f.Name == name);
        }
    }
}
