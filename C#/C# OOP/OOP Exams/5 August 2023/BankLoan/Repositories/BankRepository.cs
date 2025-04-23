namespace BankLoan.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using BankLoan.Models.Contracts;
    using BankLoan.Repositories.Contracts;

    public class BankRepository : IRepository<IBank>
    {
        private ICollection<IBank> banks;

        public BankRepository()
        {
            this.banks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => 
            (IReadOnlyCollection<IBank>)this.banks;

        public void AddModel(IBank model)
        {
            this.banks.Add(model);
        }

        public bool RemoveModel(IBank model)
        {
            return this.banks.Remove(model);
        }

        public IBank FirstModel(string name)
        {
            return this.banks.FirstOrDefault(b => b.Name == name);
        }
    }
}
