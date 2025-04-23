namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int INITIAL_INTEREST_PERCENT = 4;

        public Adult(string name, string id, double income) 
            : base(name, id, INITIAL_INTEREST_PERCENT, income)
        {
        }

        public override void IncreaseInterest()
        {
            base.Interest += 2;
        }
    }
}
