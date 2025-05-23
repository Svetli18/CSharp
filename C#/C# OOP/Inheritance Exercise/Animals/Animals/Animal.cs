﻿namespace Animals.Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get { return name; }
            protected set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public int Age 
        {
            get { return age; }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return gender; }
            protected set
            {
                if ((value != "Male" && value != "Female"))
                {
                    throw new ArgumentException();
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
