namespace BankLoan.Models.Loan
{
    public class StudentLoan : Loan
    {
        private const int INITIAL_INTEREST_RATE = 1;
        private const int INITIAL_AMOUNT = 10000;


        public StudentLoan() 
            : base(INITIAL_INTEREST_RATE, INITIAL_AMOUNT)
        {
        }
    }
}
