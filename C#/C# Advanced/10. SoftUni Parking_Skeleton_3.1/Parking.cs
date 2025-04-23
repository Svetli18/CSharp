using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking()
        {
            this.cars = new Dictionary<string, Car>();
        }

        public Parking(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public Dictionary<string, Car> Cars { get => this.cars; }

        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Count { get => this.Cars.Count; }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Cars.Count == this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars[registrationNumber];

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumb in registrationNumbers)
            {
                cars.Remove(registrationNumb);
            }
        }
    }
}
