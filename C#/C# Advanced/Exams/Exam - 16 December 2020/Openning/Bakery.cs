namespace BakeryOpenning
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Bakery
    {
        List<Employee> data;

        private Bakery()
        {
            this.data = new List<Employee>();
        }

        public Bakery(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.data.FirstOrDefault(e => e.Name == name);

            return this.data.Remove(employee);
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = this.data.OrderByDescending(e => e.Age).FirstOrDefault();

            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.data.FirstOrDefault(e => e.Name == name);

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
