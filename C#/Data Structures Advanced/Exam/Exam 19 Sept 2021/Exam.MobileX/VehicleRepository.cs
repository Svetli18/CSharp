namespace Exam.MobileX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    public class VehicleRepository : IVehicleRepository
    {
        HashSet<Vehicle> vehicles = new HashSet<Vehicle>();
        Dictionary<string, Vehicle> byIdVehicles = new Dictionary<string, Vehicle>();
        Dictionary<string, List<Vehicle>> bySellerAndVehicles = new Dictionary<string, List<Vehicle>>();
        Dictionary<string, List<Vehicle>> byBrandAndVehicles = new Dictionary<string, List<Vehicle>>();
        OrderedDictionary<double, HashSet<Vehicle>> byPriceAndVehicles = new OrderedDictionary<double, HashSet<Vehicle>>();
        SortedSet<Vehicle> isVIPVehicles = new SortedSet<Vehicle>();
        SortedSet<Vehicle> isNonVIPVehicles = new SortedSet<Vehicle>();

        public int Count => this.byIdVehicles.Count;

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!this.bySellerAndVehicles.ContainsKey(sellerName))
            {
                this.bySellerAndVehicles[sellerName] = new List<Vehicle>();
            }

            if (!this.byBrandAndVehicles.ContainsKey(vehicle.Brand))
            {
                this.byBrandAndVehicles[vehicle.Brand] = new List<Vehicle>();
            }

            if (!this.byPriceAndVehicles.ContainsKey(vehicle.Price))
            {
                this.byPriceAndVehicles[vehicle.Price] = new HashSet<Vehicle>();
            }

            if (!this.byIdVehicles.ContainsKey(vehicle.Id))//tuk move da ne se nalaga proverkata!
            {
                vehicle.SellerName = sellerName;
                this.vehicles.Add(vehicle);
                this.byIdVehicles[vehicle.Id] = vehicle;
                this.bySellerAndVehicles[sellerName].Add(vehicle);
                this.byBrandAndVehicles[vehicle.Brand].Add(vehicle);
                this.byPriceAndVehicles[vehicle.Price].Add(vehicle);

                if (vehicle.IsVIP == true)
                {
                    this.isVIPVehicles.Add(vehicle);
                }
                else
                {
                    this.isNonVIPVehicles.Add(vehicle);
                }
            }
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.bySellerAndVehicles.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            Vehicle result = null;

            double smallestPrice = double.MaxValue;

            foreach (var vehicle in this.bySellerAndVehicles[sellerName])
            {
                if (vehicle.Price < smallestPrice)
                {
                    smallestPrice = vehicle.Price;
                    result = vehicle;
                }
            }

            this.RemoveVehicle(result.Id);

            return result;
        }

        public bool Contains(Vehicle vehicle)
        {
            return this.byIdVehicles.ContainsKey(vehicle.Id);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (this.vehicles.Count == 0)
            {
                throw new ArgumentException();
            }

            var toInsert = this.byBrandAndVehicles
                .SelectMany(v => v.Value)
                .OrderBy(v => v.Price);

            Dictionary<string, List<Vehicle>> result = new Dictionary<string, List<Vehicle>>();

            foreach (var vehicle in toInsert)
            {
                if (!result.ContainsKey(vehicle.Brand))
                {
                    result[vehicle.Brand] = new List<Vehicle>();
                }

                result[vehicle.Brand].Add(vehicle);
            }

            return result;
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            if (this.vehicles.Count == 0)
            {
                return new List<Vehicle>();
            }

            return this.vehicles
                .OrderByDescending(v => v.Horsepower)
                .ThenBy(v => v.Price)
                .ThenBy(v => v.SellerName);
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            string brand = keywords[0];
            string model = keywords[1];
            string location = keywords[2];
            string color = keywords[3];

            List<Vehicle> result = new List<Vehicle>();

            result = this.isVIPVehicles
                .Where(v =>
                v.Brand == brand ||
                v.Model == model ||
                v.Location == location ||
                v.Color == color).ToList();

            result.AddRange(this.isNonVIPVehicles.Where(v =>
                v.Brand == brand ||
                v.Model == model ||
                v.Location == location ||
                v.Color == color).ToList());

            return result;
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.bySellerAndVehicles.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            return this.bySellerAndVehicles[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            if (!this.byPriceAndVehicles.Any(v => lowerBound <= v.Key && v.Key <= upperBound))
            {
                new List<Vehicle>();
            }

            return this.byPriceAndVehicles
                .Range(lowerBound, true, upperBound, true)
                .SelectMany(v => v.Value)
                .OrderByDescending(v => v.Horsepower);
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!this.byIdVehicles.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            Vehicle vehicle = this.byIdVehicles[vehicleId];

            vehicle.SellerName = string.Empty;
            this.vehicles.Remove(vehicle);
            this.byIdVehicles.Remove(vehicleId);
            this.bySellerAndVehicles[vehicle.SellerName].Remove(vehicle);
            this.byBrandAndVehicles[vehicle.Brand].Remove(vehicle);
            this.byPriceAndVehicles[vehicle.Price].Remove(vehicle);

            if (vehicle.IsVIP == true)
            {
                this.isVIPVehicles.Remove(vehicle);
            }
            else
            {
                this.isNonVIPVehicles.Remove(vehicle);
            }
        }
    }
}
