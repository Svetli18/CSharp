using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {
         //this.Model = "VW";
         //this.Engine = new Engine(220, 220);
         //this.Cargo = new Cargo(1000, "Unknown");
         //this.tires = new Tire[]{new Tire(2.2, 0), new Tire(2.2, 0), new Tire(2.2, 0), new Tire(2.2, 0)};
        }

        public Car(string model)
            : this()
        {
            this.Model = model;
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
            : this(model)
        {
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get => this.model; set => this.model = value; }

        public Engine Engine { get => this.engine; set => this.engine = value; }

        public Cargo Cargo { get => this.cargo; set => this.cargo = value; }

        public Tire[] Tires { get => this.tires; set => this.tires = value; }

        public override string ToString()
        {
            return $"{this.Model}";
        }

    }
}
