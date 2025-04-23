using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire()
        {          
        }

        public Tire(int year = 0, double pressure = 0)
            :this()
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get => this.year; set => this.year = value; }
        public double Pressure { get => this.pressure; set => this.pressure = value; }

    }
}
