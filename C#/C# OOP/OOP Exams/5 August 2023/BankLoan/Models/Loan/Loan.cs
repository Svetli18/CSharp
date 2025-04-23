namespace BankLoan.Models.Loan
{
    using BankLoan.Models.Contracts;

    public abstract class Loan : ILoan
    {
        public Loan(int interestRate, double amount)
        {
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        public int InterestRate {  get; private set; }

        public double Amount {  get; private set; }
    }
}
