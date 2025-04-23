namespace Animals
{
    using Animals;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] typeArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = typeArgs[0];
                int age = int.Parse(typeArgs[1]);
                string gender = typeArgs[2];

                Animal animal = null;

                try
                {
                    if (type == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (type == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(name, age, gender);
                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(name, age, gender);
                    }

                    animals.Add(animal);

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

        }
    }
}
