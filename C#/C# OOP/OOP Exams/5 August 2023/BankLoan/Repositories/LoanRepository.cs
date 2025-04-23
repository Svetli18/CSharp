namespace BankLoan.Repositories
{
    using BankLoan.Models.Contracts;
    using BankLoan.Models.Loan;
    using BankLoan.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoanRepository : IRepository<ILoan>
    {
        private ICollection<ILoan> loans;

        public LoanRepository()
        {
            this.loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models => 
            (IReadOnlyCollection<ILoan>)this.loans;

        public void AddModel(ILoan model)
        {
            this.loans.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            return this.loans.Remove(model);
        }

        public ILoan FirstModel(string name)
        {
            return this.loans.FirstOrDefault(l => l.GetType().Name == name);
        }

        public static implicit operator LoanRepository(MortgageLoan v)
        {
            throw new NotImplementedException();
        }
    }
}
