namespace Handball.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Handball.Models.Contracts;
    using Handball.Repositories.Contracts;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => 
            (IReadOnlyCollection<IPlayer>)this.models;

        public void AddModel(IPlayer model)
        {
            this.models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return this.models.Remove(GetModel(name));
        }

        public bool ExistsModel(string name)
        {
            return GetModel(name) != null ? true : false;
        }

        public IPlayer GetModel(string name)
        {
            return this.models.FirstOrDefault(p => p.Name == name);
        }
    }
}
