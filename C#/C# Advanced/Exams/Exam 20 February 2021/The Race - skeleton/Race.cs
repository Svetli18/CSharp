namespace TheRace
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Race
    {
        private List<Racer> data;

        private Race()
        {
            this.data = new List<Racer>();
        }

        public Race(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Racer Racer)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = this.data.FirstOrDefault(r => r.Name == name);

            return this.data.Remove(racer);
        }

        public Racer GetOldestRacer()
        {
            Racer racer = this.data.OrderByDescending(r => r.Age).FirstOrDefault();

            return racer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = this.data.FirstOrDefault(r => r.Name == name);

            return racer;

        }

        public Racer GetFastestRacer()
        {
            Racer racer = this.data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

            return racer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
