using System;
using System.Diagnostics.CodeAnalysis;

namespace Kubernetes
{
    public class Pod : IComparable<Pod>
    {
        public string Id { get; set; }

        public string ServiceName { get; set; }

        public int Port { get; set; }

        public string Namespace { get; set; }

        public int CompareTo([AllowNull] Pod other)
        {
            int comparer = other.Port.CompareTo(this.Port);

            if (comparer == 0)
            {
                return this.Namespace.CompareTo(other.Namespace);
            }

            return comparer;
        }

        public override bool Equals(object obj)
        {
            Pod other = obj as Pod;

            if (other == null) return false;

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}