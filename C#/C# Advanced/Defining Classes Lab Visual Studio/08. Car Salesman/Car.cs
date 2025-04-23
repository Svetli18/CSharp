using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car()
        {
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine)
            :this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            :this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get => this.model; set => this.model = value; }

        public Engine Engine { get => this.engine; set => this.engine = value; }

        public int Weight { get => this.weight; set => this.weight = value; }

        public string Color { get => this.color; set => this.color = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string weightToString = this.Weight > -1 ? this.Weight.ToString() : "n/a";

            sb.AppendLine($"{this.Model}");
            sb.AppendLine($"  {this.Engine}");
            sb.AppendLine($"  Weight: {weightToString}");
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }

    }
}
