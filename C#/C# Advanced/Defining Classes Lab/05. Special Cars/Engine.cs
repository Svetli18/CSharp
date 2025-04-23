using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine()
        {          
        }

        public Engine(int horsePower = 0, double cubicCapacity = 0)
            :this()
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }

        public double CubicCapacity { get => this.cubicCapacity; set => this.cubicCapacity = value; }

    }
}
