namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class DogVet : IDogVet
    {
        Dictionary<string, Owner> owners = new Dictionary<string, Owner>();
        Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
        Dictionary<string, Dictionary<string, Dog>> byOwnerIdAndDogName = new Dictionary<string, Dictionary<string, Dog>>();

        public int Size { get { return this.dogs.Count; } }

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogs.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (!this.owners.ContainsKey(owner.Id))
            {
                this.owners[owner.Id] = owner;
                this.byOwnerIdAndDogName[owner.Id] = new Dictionary<string, Dog>();
            }

            if (this.byOwnerIdAndDogName[owner.Id].ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            dog.Owner = owner;
            this.dogs[dog.Id] = dog;
            this.byOwnerIdAndDogName[owner.Id][dog.Name] = dog;
        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.byOwnerIdAndDogName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.byOwnerIdAndDogName[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.byOwnerIdAndDogName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Dog dog = this.byOwnerIdAndDogName[ownerId][name];

            dog.Owner = null;
            this.dogs.Remove(dog.Id);
            this.byOwnerIdAndDogName[ownerId].Remove(name);

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.byOwnerIdAndDogName[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            ICollection<Dog> result = this.dogs.Values.Where(d => d.Breed == breed).ToList();

            if (result.Count == 0)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.byOwnerIdAndDogName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Dog dog = this.byOwnerIdAndDogName[ownerId][name];

            dog.Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.byOwnerIdAndDogName[ownerId].ContainsKey(oldName))
            {
                throw new ArgumentException();
            }

            Dog dog = this.byOwnerIdAndDogName[ownerId][oldName];

            this.byOwnerIdAndDogName[ownerId].Remove(oldName);

            if (this.byOwnerIdAndDogName[ownerId].ContainsKey(newName))
            {
                throw new ArgumentException();
            }

            dog.Name = newName;

            this.byOwnerIdAndDogName[ownerId][newName] = dog;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            ICollection<Dog> result = this.dogs.Values.Where(d => d.Age == age).ToList();

            if (0 == result.Count)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            ICollection<Dog> result = this.dogs.Values.Where(d => lo <= d.Age && d.Age <= hi).ToList();

            return result;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            ICollection<Dog> result = this.dogs.Values.OrderBy(d => d.Age).ThenBy(d => d.Name).ThenBy(o => o.Owner.Id).ToList();

            return result;
        }
    }
}