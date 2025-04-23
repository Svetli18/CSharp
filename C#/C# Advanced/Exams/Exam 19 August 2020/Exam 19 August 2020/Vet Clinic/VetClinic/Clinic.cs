namespace VetClinic
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        private List<Pet> data;

        private Clinic()
        {
            this.data = new List<Pet>();
        }

        public Clinic(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name);

            return this.data.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.data.OrderByDescending(p => p.Age).FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
