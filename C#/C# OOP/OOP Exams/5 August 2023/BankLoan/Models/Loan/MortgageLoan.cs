namespace BankLoan.Models.Loan
{
    using BankLoan.Models.Contracts;
    using System;

    public class MortgageLoan : Loan
    {
        private const int INITIAL_INTEREST_RATE = 3;
        private const int INITIAL_AMOUNT = 50000;


        public MortgageLoan()
            : base(INITIAL_INTEREST_RATE, INITIAL_AMOUNT)
        {
        }
    }
}
