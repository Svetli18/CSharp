namespace NationalElectionSystem
{
    using System;
    using System.Diagnostics.CodeAnalysis;


    public class Candidate : IComparable<Candidate>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Party { get; set; }

        public int Voters { get; set; }

        public int CompareTo([AllowNull] Candidate other)
        {
            return this.Voters - other.Voters;
        }
    }
}