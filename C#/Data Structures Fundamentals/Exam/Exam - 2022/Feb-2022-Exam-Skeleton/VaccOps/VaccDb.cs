namespace VaccOps
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using Models;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> _doctors;
        private HashSet<Patient> _patients;

        public VaccDb()
        {
            this._doctors = new Dictionary<string, Doctor>();
            this._patients = new HashSet<Patient>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!this._doctors.ContainsKey(doctor.Name))
            {
                this._doctors[doctor.Name] = doctor;
            }
            else
            {
                throw new ArgumentException();                
            }
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this._doctors.ContainsKey(doctor.Name) || this._doctors[doctor.Name].MyPatients.Contains(patient))
            {
                throw new ArgumentException();
            }

            if (!this._patients.Contains(patient))
            {
                this._patients.Add(patient);
            }

            if (!this._doctors[doctor.Name].MyPatients.Contains(patient))
            {
                this._doctors[doctor.Name].AddPatient(patient);
            }
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return new List<Doctor>(this._doctors.Values);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return new List<Patient>(this._patients);
        }

        public bool Exist(Doctor doctor)
        {
            return this._doctors.ContainsKey(doctor.Name);
        }

        public bool Exist(Patient patient)
        {
            return this._patients.Contains(patient);
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!this._doctors.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Doctor doctor = this._doctors[name];

            List<Patient> patients = new List<Patient>(doctor.MyPatients);

            foreach (var patient in patients)
            {
                doctor.RemovePatient(patient);
                this._patients.Remove(patient);
            }

            this._doctors.Remove(name);

            return doctor;
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this._doctors.ContainsKey(oldDoctor.Name) || 
                !this._doctors.ContainsKey(newDoctor.Name) || 
                !this._patients.Contains(patient))
            {
                throw new ArgumentException();
            }

            oldDoctor.RemovePatient(patient);
            newDoctor.AddPatient(patient);
        }


        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            List<Doctor> result = new List<Doctor>();

            foreach (var doctor in this._doctors.Values)
            {
                if (doctor.Popularity.Equals(populariry))
                {
                    result.Add(doctor);
                }
            }

            return result;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            List<Patient> result = new List<Patient>();

            foreach (var patient in this._patients)
            {
                if (patient.Town.Equals(town))
                {
                    result.Add(patient);
                }
            }

            return result;
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            List<Patient> result = new List<Patient>();

            foreach (var patient in this._patients)
            {
                if (lo <= patient.Age && patient.Age <= hi)
                {
                    result.Add(patient);
                }
            }

            return result;
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            List<Doctor> result = new List<Doctor>(this._doctors.Values
                .OrderByDescending(d => d.MyPatients.Count)
                .ThenBy(d => d.Name));

            return result;
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            List<Patient> result = new List<Patient>(this._patients.OrderBy(p => p.MyDoctor.Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age));

            return result;
        }
    }
}
