namespace BankLoan.Core
{
    using System;
    using System.Text;

    using BankLoan.Core.Contracts;
    using BankLoan.Models;
    using BankLoan.Models.Loan;
    using BankLoan.Models.Contracts;
    using BankLoan.Repositories;
    using BankLoan.Utilities.Messages;

    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            this.loans = new LoanRepository();
            this.banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = null;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            this.banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;

            if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            this.loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = this.banks.FirstModel(bankName);

            ILoan loan = this.loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            this.loans.RemoveModel(loan);

            bank.AddLoan(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = null;

            if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = this.banks.FirstModel(bankName);

            if (client.GetType().Name == "Student" && 
                bank.GetType().Name == "CentralBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            else if(client.GetType().Name == "Adult" &&
                    bank.GetType().Name == "BranchBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);                
            }
            else
            {
                bank.AddClient(client);

                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
        }


        public string FinalCalculation(string bankName)
        {
            IBank bank = this.banks.FirstModel(bankName);

            double funds = 0;

            foreach (var client in bank.Clients)
            {
                funds += client.Income;
            }

            foreach (var loan in bank.Loans)
            {
                funds += loan.Amount;
            }

            string strFunds = $"{funds:F2}";

            return string.Format(OutputMessages.BankFundsCalculated, bankName, strFunds);
        }


        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currBank in this.banks.Models)
            {
                sb.AppendLine(currBank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
