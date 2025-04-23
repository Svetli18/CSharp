using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.PackageManagerLite
{
    public class PackageManager : IPackageManager
    {
        private HashSet<Package> packages = new HashSet<Package>();
        private Dictionary<string, Package> byId = new Dictionary<string, Package>();

        public void RegisterPackage(Package package)
        {
            if (this.packages.Any(x => x.Name.Equals(package.Name) && x.Version.Equals(package.Version)))
            {
                throw new ArgumentException();
            }

            this.packages.Add(package);
            this.byId[package.Id] = package;
        }

        public void RemovePackage(string packageId)
        {
            if (!this.byId.ContainsKey(packageId))
            {
                throw new ArgumentException();
            }

            Package package = this.byId[packageId];

            var dependPackages = this.packages.Where(p => p.Dependants.ContainsKey(packageId));

            foreach (var current in dependPackages)
            {
                current.Dependants.Remove(packageId);
            }

            this.packages.Remove(package);
            this.byId.Remove(package.Id);
        }

        public void AddDependency(string packageId, string dependencyId)
        {
            if (!this.byId.ContainsKey(packageId) || !this.byId.ContainsKey(dependencyId))
            {
                throw new ArgumentException();
            }

            Package package = this.byId[packageId];
            Package dependency = this.byId[dependencyId];

            package.Dependants[dependency.Id] = dependency;
        }

        public bool Contains(Package package)
        {
            return this.byId.ContainsKey(package.Id);
        }

        public int Count()
        {
            return this.byId.Count;
        }

        public IEnumerable<Package> GetDependants(Package package)
        {
            List<Package> result = new List<Package>(this.byId[package.Id].Dependants.Values);

            if (result.Count == 0)
            {
                return new List<Package>();
            }

            return result;
        }

        public IEnumerable<Package> GetIndependentPackages()
        {
            var result = this.byId.Values
                .Where(p => p.Dependants.Count == 0)
                .OrderByDescending(p => p.ReleaseDate)
                .ThenBy(p => p.Version);

            if (!result.Any())
            {
                return new List<Package>();
            }

            return result;
        }

        public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
        {
            Dictionary<string, SortedSet<Package>> collection  = new Dictionary<string, SortedSet<Package>>();

            foreach (var package in this.packages)
            {
                if (!collection.ContainsKey(package.Version))
                {
                    collection[package.Version] = new SortedSet<Package>();
                }

                collection[package.Version].Add(package);

                if (1 < collection[package.Version].Count)
                {
                    Package current = collection[package.Version].LastOrDefault();
                    collection[package.Version].Clear();
                    collection[package.Version].Add(current);
                }
            }

            return collection.SelectMany(x => x.Value).OrderByDescending(x => x.ReleaseDate).ThenBy(x => x.Version);
        }
    }
}
