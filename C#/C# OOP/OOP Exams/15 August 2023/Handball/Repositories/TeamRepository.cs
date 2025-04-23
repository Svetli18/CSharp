namespace Handball.Repositories
{
    using Handball.Models.Contracts;
    using Handball.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class TeamRepository : IRepository<ITeam>
    {
        private ICollection<ITeam> models;

        public TeamRepository()
        {
            this.models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => 
            (IReadOnlyCollection<ITeam>)this.models;

        public void AddModel(ITeam model)
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

        public ITeam GetModel(string name)
        {
            return this.models.FirstOrDefault(t => t.Name == name);
        }
    }
}
