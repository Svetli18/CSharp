namespace VaccOps.Models
{
    using System.Collections.Generic;
    public class Doctor
    {
        private SortedDictionary<string, Patient> patients;

        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
            this.patients = new SortedDictionary<string, Patient>();
        }

        public string Name { get; set; }
        public int Popularity { get; set; }

        public SortedDictionary<string,  Patient> Patients { get { return this.Patients; } }

        public void AddPatient(string name, Patient patient)
        {//TODO tuk moje da iska da throw exception, ako opitame da add sushtiq pacient
            if (!this.Patients.ContainsKey(name))
            {
                this.patients.Add(name, patient);
                patient.MyDoctor = this;
            }
        }

        public void RemovePatient(string name)
        {//TODO tuk moje da iska da throw exception, ako opitame da Remove pacient koito ne sushtetvova!
            if (this.patients.ContainsKey(name))
            {
                this.patients.Remove(name);
                Patient patient = this.patients[name];
                patient.MyDoctor = null;
            }
        }
    }
}
