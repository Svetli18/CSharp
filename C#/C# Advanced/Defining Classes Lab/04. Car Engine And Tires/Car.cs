﻿using System;
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

        private double fuelQuantity;

        private double fuelConsumption;

        private Engine engine;

        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
            this.Engine = new Engine(220, 2000);
            this.tires = new Tire[4]
            {
                new Tire(2023, 2.3),
                new Tire(2023, 2.3),
                new Tire(2023, 2.3),
                new Tire(2023, 2.3)
            };

        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get => this.make; set => this.make = value; }

        public string Model { get => this.model; set => this.model = value; }

        public int Year { get => this.year; set => this.year = value; }

        public double FuelQuantity { get => this.fuelQuantity; set => this.fuelQuantity = value; }

        public double FuelConsumption { get => this.fuelConsumption; set => this.fuelConsumption = value; }

        public Engine Engine { get => this.engine; set => this.engine = value; }

        public Tire[] Tires { get => this.tires; set => this.tires = value; }

        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - ((distance * this.FuelConsumption) / 100) >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption) / 100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
