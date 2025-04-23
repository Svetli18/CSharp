using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
   public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine()
        {
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power)
            :this()
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            :this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get => this.model; set => this.model = value; }

        public int Power { get => this.power; set => this.power = value; }

        public int Displacement { get => this.displacement; set => this.displacement = value; }

        public string Efficiency { get => this.efficiency; set => this.efficiency = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string dispacementToString = this.Displacement > -1 ? this.Displacement.ToString() : "n/a";

            sb.AppendLine($"{this.Model}");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {dispacementToString}");
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }

    }
}
