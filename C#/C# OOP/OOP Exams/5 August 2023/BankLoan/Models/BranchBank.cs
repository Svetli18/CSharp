namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        private const int INITIAL_BANK_CAPACITY = 25;

        public BranchBank(string name)
            :base(name, INITIAL_BANK_CAPACITY)
        {
            
        }
    }
}
