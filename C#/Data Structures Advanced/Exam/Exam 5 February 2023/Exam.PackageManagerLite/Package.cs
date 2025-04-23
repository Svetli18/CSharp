namespace Exam.PackageManagerLite
{
    using System;
    using System.Collections.Generic;

    public class Package
    {

        public Package(string id, string name, DateTime releaseDate, string version)
        {
            this.Id = id;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.Version = version;
            this.Dependants = new Dictionary<string, Package>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public Dictionary<string, Package> Dependants;

        public override bool Equals(object obj)
        {
            Package other = obj as Package;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
