namespace _02.VaniPlanning
{
    using System;

    public class Invoice : IComparable<Invoice>
    {
        public Invoice(string number, string company, double subtotal, Department dep, DateTime issueDate, DateTime dueDate)
        {
            this.SerialNumber = number;
            this.CompanyName = company;
            this.Subtotal = subtotal;
            this.Department = dep;
            this.IssueDate = issueDate;
            this.DueDate = dueDate;
        }
        public string SerialNumber { get; set; }

        public string CompanyName { get; set; }

        public double Subtotal { get; set; }

        public Department Department { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public int CompareTo(Invoice other)
        {
            int compare = other.SerialNumber.CompareTo(this.SerialNumber);

            if (compare == 0)
            {
                int compare1 = (int)(other.Subtotal * 100 - this.Subtotal * 100);

                if (compare1 == 0)
                {
                    int compare2 = this.IssueDate.CompareTo(other.IssueDate);

                    if (compare2 == 0)
                    {
                        return this.DueDate.CompareTo(other.DueDate);
                    }

                    return compare2;
                }

                return compare1;
            }

            return compare;
        }

        public override bool Equals(object obj)
        {
            Invoice other = obj as Invoice;

            if (other == null)
            {
                return false;
            }

            return this.SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return this.SerialNumber.GetHashCode();
        }
    }
}
