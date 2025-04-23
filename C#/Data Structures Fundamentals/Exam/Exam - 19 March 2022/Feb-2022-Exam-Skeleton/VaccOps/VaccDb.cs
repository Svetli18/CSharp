namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class VaccDb : IVaccOps
    {
        private SortedDictionary<string, Doctor> _doctors;
        private SortedDictionary<string, Patient> _patients;

        public VaccDb()
        {
            this._doctors = new SortedDictionary<string, Doctor>();
            this._patients = new SortedDictionary<string, Patient>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (this._doctors.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this._doctors[doctor.Name] = doctor;
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this._doctors.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            if (!this._patients.ContainsKey(patient.Name))
            {
                this._patients[patient.Name] = patient;
            }

            this._doctors[doctor.Name].AddPatient(patient.Name, patient);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return this._doctors.Values;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return this._patients.Values;
        }

        public bool Exist(Doctor doctor)
        {
            return this._doctors.ContainsKey(doctor.Name);
        }

        public bool Exist(Patient patient)
        {
            return this._patients.ContainsKey(patient.Name);
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!this._doctors.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Doctor doctor = this._doctors[name];

            foreach (var patient in doctor.Patients.Values)
            {//TODO tuk moje da iska da vurna doctora sus pacientite mu!!
                patient.MyDoctor = null;
                this._patients.Remove(patient.Name);
            }

            return doctor;
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            throw new NotImplementedException();
        }
    }
}
