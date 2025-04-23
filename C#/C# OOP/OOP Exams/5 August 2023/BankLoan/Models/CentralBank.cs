namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int INITIAL_BANK_CAPACITY = 50;

        public CentralBank(string name)
            : base(name, INITIAL_BANK_CAPACITY)
        {

        }
    }
}
