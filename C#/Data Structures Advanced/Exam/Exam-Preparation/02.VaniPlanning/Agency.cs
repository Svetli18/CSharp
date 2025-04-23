namespace _02.VaniPlanning
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Agency : IAgency
    {
        SortedSet<Invoice> invoices = new SortedSet<Invoice>();
        Dictionary<string, Invoice> byNumber = new Dictionary<string, Invoice>();
        //SortedDictionary<DateTime, List<Invoice>> byDueDate = new SortedDictionary<DateTime, List<Invoice>>();
        //SortedDictionary<DateTime, List<Invoice>> byIssueDate = new SortedDictionary<DateTime, List<Invoice>>();
        //Dictionary<Department, List<Invoice>> byDepartment = new Dictionary<Department, List<Invoice>>();
        //Dictionary<string, List<Invoice>> byCompany = new Dictionary<string, List<Invoice>>();

        public void Create(Invoice invoice)
        {
            if (this.byNumber.ContainsKey(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            //if (!this.byDueDate.ContainsKey(invoice.DueDate))
            //{
            //    this.byDueDate[invoice.DueDate] = new List<Invoice>();
            //}

            //if (!this.byIssueDate.ContainsKey(invoice.IssueDate))
            //{
            //    this.byIssueDate[invoice.IssueDate] = new List<Invoice>();
            //}

            //if (!this.byDepartment.ContainsKey(invoice.Department))
            //{
            //    this.byDepartment[invoice.Department] = new List<Invoice>();
            //}

            //if (!this.byCompany.ContainsKey(invoice.CompanyName))
            //{
            //    this.byCompany[invoice.CompanyName] = new List<Invoice>();
            //}

            this.invoices.Add(invoice);
            this.byNumber[invoice.SerialNumber] = invoice;
            //this.byDueDate[invoice.DueDate].Add(invoice);
            //this.byIssueDate[invoice.IssueDate].Add(invoice);
            //this.byDepartment[invoice.Department].Add(invoice);
            //this.byCompany[invoice.CompanyName].Add(invoice);
        }

        public void ThrowInvoice(string number)
        {
            if (!this.byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            Invoice invoice = this.byNumber[number];

            this.invoices.Remove(invoice);
            this.byNumber.Remove(number);
            //this.byDueDate[invoice.DueDate].Remove(invoice);
            //this.byIssueDate[invoice.IssueDate].Remove(invoice);
            //this.byDepartment[invoice.Department].Remove(invoice);
            //this.byCompany[invoice.CompanyName].Remove(invoice);

            //if (!this.byDueDate[invoice.DueDate].Any())
            //{
            //    this.byDueDate.Remove(invoice.DueDate);
            //}

            //if (!this.byIssueDate[invoice.IssueDate].Any())
            //{
            //    this.byIssueDate.Remove(invoice.IssueDate);
            //}

            //if (!this.byDepartment[invoice.Department].Any())
            //{
            //    this.byDepartment.Remove(invoice.Department);
            //}

            //if (!this.byCompany[invoice.CompanyName].Any())
            //{
            //    this.byCompany.Remove(invoice.CompanyName);
            //}
        }

        public void ThrowPayed()
        {
            //var invoicesToRemove = this.invoices.Where(i => i.Subtotal == 0).ToList();

            foreach (var invoice in this.invoices.Where(i => i.Subtotal == 0).ToList())
            {
                this.invoices.Remove(invoice);
                this.byNumber.Remove(invoice.SerialNumber);
                //this.byDueDate[invoice.DueDate].Remove(invoice);

                //if (!this.byDueDate[invoice.DueDate].Any())
                //{
                //    this.byDueDate.Remove(invoice.DueDate);
                //}
            }   //0895834464
        }

        public int Count()
        {
            return this.invoices.Count;
        }

        public bool Contains(string number)
        {
            return this.byNumber.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            if (!this.invoices.Any(i => i.DueDate == due))
            {
                throw new ArgumentException();
            }

            foreach (var invoice in this.invoices.Where(i => i.DueDate == due))
            {
                invoice.Subtotal = 0;
            }

            //this.invoices
            //    .Where(i => i.DueDate == due)
            //    .Select(i => i.Subtotal = 0);

            //if (!this.byDueDate.ContainsKey(due))
            //{
            //    throw new ArgumentException();
            //}

            //this.byDueDate[due].ForEach(i => i.Subtotal = 0);
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            if (!this.invoices.Any(k => start <= k.IssueDate && k.IssueDate <= end))
            {
                return new List<Invoice>();
            }

            return this.invoices.Where(i => start <= i.IssueDate && i.IssueDate <= end).Reverse();
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            if (!this.byNumber.Keys.Where(i => i.Contains(serialNumber)).Any())
            {
                throw new ArgumentException();
            }

            return this.invoices.Where(i => i.SerialNumber.Contains(serialNumber));
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            if (!this.invoices.Any(i => start < i.DueDate && i.DueDate < end))//!this.byDueDate.Keys.Where(i => start < i && i < end)
            {
                throw new ArgumentException();
            }

            var forRemove = this.byNumber.Values.Where(k => start < k.DueDate && k.DueDate < end);

            foreach (var invoice in forRemove)
            {
                this.ThrowInvoice(invoice.SerialNumber);
            }

            return forRemove;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            if (!this.invoices.Any(i => i.Department.Equals(department)))
            {
                return new List<Invoice>();
            }

            return this.invoices.Where(i => i.Department.Equals(department));
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            if (!this.invoices.Any(i => i.CompanyName.Equals(company)))
            {
                return new List<Invoice>();
            }

            return this.invoices.Where(i => i.CompanyName.Equals(company));
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            if (!this.invoices.Any(i => i.DueDate == dueDate))
            {
                throw new ArgumentException();
            }
            //if (!this.byDueDate.ContainsKey(dueDate))
            //{
            //    throw new ArgumentException();
            //}

            foreach (var invoice in this.invoices.Where(i => i.DueDate == dueDate))
            {
                invoice.DueDate = invoice.DueDate.AddDays(days);
            }

            //this.invoices
            //    .Where(i => i.DueDate == dueDate)
            //    .Select(i => i.DueDate = i.DueDate.AddDays(days));

            //foreach (var invoice in this.byDueDate[dueDate])
            //{
            //    invoice.DueDate = invoice.DueDate.AddDays(days);

            //    if (!this.byDueDate.ContainsKey(invoice.DueDate))
            //    {
            //        this.byDueDate[invoice.DueDate] = new List<Invoice>();
            //    }

            //    this.byDueDate[invoice.DueDate].Add(invoice);
            //}

            //this.byDueDate.Remove(dueDate);
        }
    }
}
