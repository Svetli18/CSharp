using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire()
        {
        }

        public Tire(double pressure, int age)
            :this()
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get => this.pressure; set => this.pressure = value; }

        public int Age { get => this.age; set => this.age = value; }    

    }
}
