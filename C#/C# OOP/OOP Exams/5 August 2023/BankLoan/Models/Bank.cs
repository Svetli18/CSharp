namespace BankLoan.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using BankLoan.Models.Contracts;
    using BankLoan.Utilities.Messages;

    public abstract class Bank : IBank
    {
        private string name;
        private ICollection<ILoan> loans;
        private ICollection<IClient> clients;

        private Bank()
        {
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }

        public Bank(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => 
            (IReadOnlyCollection<ILoan>)this.loans;

        public IReadOnlyCollection<IClient> Clients => 
            (IReadOnlyCollection<IClient>)this.clients;

        public void AddClient(IClient Client)
        {
            if (this.clients.Count == this.Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            this.clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            string clieantsStr = "Clients: none";

            if (this.clients.Count > 0)
            {
                clieantsStr = "Clients: ";

                int ctr = 0;

                foreach (IClient client in this.clients)
                {
                    if (ctr == 0)
                    {
                        clieantsStr += client.Name;
                        ctr++;
                        continue;
                    }


                     clieantsStr += ", " + client.Name;
                }
            }

            int result = 0;

            foreach (var loan in this.loans)
            {
                result += loan.InterestRate;
            }

            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            sb.AppendLine(clieantsStr);
            sb.AppendLine($"Loans: {this.Loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().TrimEnd();
        }


        public double SumRates()
        {
            double result = 0;

            foreach (var loan in this.loans)
            {
                result += loan.InterestRate;
            }

            return result;
        }
    }
}
