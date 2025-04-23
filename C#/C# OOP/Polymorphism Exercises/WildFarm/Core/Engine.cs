namespace WildFarm.Core
{
    using System;
    using WildFarm.AnimalModels;
    using WildFarm.Caontracts;
    using WildFarm.Core.Contracts;
    using WildFarm.FoodModels;
    using WildFarm.IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        private ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                try
                {
                    IAnimal animal = null;

                    string[] animalArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string animalType = animalArgs[0];

                    IFood food = null;

                    string[] foodArgs = this.reader.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string foodType = foodArgs[0];

                    switch (foodType)
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(foodArgs[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(foodArgs[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(foodArgs[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(foodArgs[1]));
                            break;
                        default: throw new ArgumentException($"This {animalType} doesn't exist!");
                    }

                    Type type = null;

                    switch (animalType)
                    {
                        case "Owl":
                            animal =
                                new Owl(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Owl owl = (Owl)Convert.ChangeType(animal, type);
                            owl.Feed(food);
                            break;
                        case "Hen":
                            animal =
                                new Hen(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Hen hen = (Hen)Convert.ChangeType(animal, type);
                            hen.Feed(food);
                            break;
                        case "Mouse":
                            animal =
                                new Mouse(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Mouse mouse = (Mouse)Convert.ChangeType(animal, type);
                            mouse.Feed(food);
                            break;
                        case "Dog":
                            animal =
                                new Dog(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Dog dog = (Dog)Convert.ChangeType(animal, type);
                            dog.Feed(food);
                            break;
                        case "Cat":
                            animal =
                                new Cat(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Cat cat = (Cat)Convert.ChangeType(animal, type);
                            cat.Feed(food);
                            break;
                        case "Tiger":
                            animal =
                                new Tiger(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
                            this.writer.WriteLine(animal.ProduceSound());
                            this.animals.Add(animal);
                            type = animal.GetType();
                            Tiger tiger = (Tiger)Convert.ChangeType(animal, type);
                            tiger.Feed(food);
                            break;
                        default: throw new ArgumentException($"This {animalType} doesn't exist!");
                    }
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            foreach (var animal in this.animals)
            {
               this.writer.WriteLine(animal.ToString());
            }

        }
    }
}
