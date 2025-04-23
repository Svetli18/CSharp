using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class Database
    {
        private Person[] persons;

        private int count;
        //ok
        public Database(params Person[] persons)
        {
            this.persons = new Person[16];
            AddRange(persons);
        }
        //ok
        public int Count
        {
            get { return count; }
        }
        //ok
        private void AddRange(Person[] data)
        {   //ok
            if (data.Length > 16)
            {
                throw new ArgumentException("Provided data length should be in range [0..16]!");
            }
            //ok
            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }
            //ok
            this.count = data.Length;
        }
        //ok
        public void Add(Person person)
        {   //ok
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }
            //ok
            if (persons.Any(p => p?.UserName == person.UserName))
            {
                throw new InvalidOperationException("There is already user with this username!");
            }
            //ok
            if (persons.Any(p => p?.Id == person.Id))
            {
                throw new InvalidOperationException("There is already user with this Id!");
            }
            //ok
            this.persons[this.count] = person;
            this.count++;
        }
        //ok
        public void Remove()
        {   //ok
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }
            //ok
            this.count--;
            this.persons[this.count] = null;
        }
        //ok
        public Person FindByUsername(string name)
        {   //ok
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username parameter is null!");
            }
            //ok
            if (this.persons.Any(p => p?.UserName == name) == false)
            {
                throw new InvalidOperationException("No user is present by this username!");
            }
            //ok
            Person person = this.persons.First(p => p.UserName == name);
            return person;
        }

        //ok
        public Person FindById(long id)
        {   //ok
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be a positive number!");
            }
            //ok
            if (this.persons.Any(p => p?.Id == id) == false)
            {
                throw new InvalidOperationException("No user is present by this ID!");
            }
            //ok
            Person person = this.persons.First(p => p.Id == id);
            return person;
        }
    }
}
