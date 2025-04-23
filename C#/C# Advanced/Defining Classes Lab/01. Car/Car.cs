using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        private string model;

        private int year;
        //public Car()
        //{            
        //}
        //public Car(string make, string model, int year)
        //    :this()
        //{
        //    Make = make;
        //    Model = model;
        //    Year = year;
        //}
        public string Make { get => this.make; set => this.make = value; }

        public string Model { get => this.model; set => this.model = value; }

        public int Year { get => this.year; set => this.year = value; }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Make: {this.Make}");
        //    sb.AppendLine($"Model: {this.Model}");
        //    sb.AppendLine($"Year: {this.Year}");
        //    return sb.ToString().TrimEnd();
        //}
    }
}
