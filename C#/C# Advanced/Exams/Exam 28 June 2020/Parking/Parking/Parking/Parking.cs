namespace Parking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Parking
    {
        private List<Car> data;

        private Parking()
        {
            this.data = new List<Car>();
        }

        public Parking(string type, int capacity)
            : this()
        {
            Type = type;
            Capacity = capacity;
        }


        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;
        
        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return this.data.Remove(car);
        }

        public Car GetLatestCar()
        {
            Car car = this.data.OrderByDescending(c => c.Year).FirstOrDefault();

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }
    }
}
