namespace VaccOps.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class Doctor : IEqualityComparer<Doctor>
    {
        private HashSet<Patient> _patients;

        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
            this._patients = new HashSet<Patient>();
        }

        public string Name { get; set; }
        public int Popularity { get; set; }

        public HashSet<Patient> MyPatients { get { return this._patients; } }

        public void AddPatient(Patient patient)
        {
            if (this._patients.Contains(patient))
            {
                throw new ArgumentException();
            }

            this._patients.Add(patient);
            patient.MyDoctor = this;
        }

        public void RemovePatient(Patient patient)
        {
            if (!this._patients.Contains(patient))
            {
                throw new ArgumentException();
            }

            patient.MyDoctor = null;
            this._patients.Remove(patient);
        }

        public bool Equals([AllowNull] Doctor x, [AllowNull] Doctor y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Doctor obj)
        {
            return base.GetHashCode();
        }
    }
}
