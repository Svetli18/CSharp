namespace BankLoan.Models
{
    using System;

    public class Student : Client
    {
        private const int INITIAL_INTEREST_PERCENT = 2;

        public Student(string name, string id, double income) 
            : base(name, id, INITIAL_INTEREST_PERCENT, income)
        {
        }

        public override void IncreaseInterest()
        {
            base.Interest++;
        }
    }
}
