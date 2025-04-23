namespace Farm
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //MyConsole myConsole = new MyConsole();

            Dog dog = new Dog();

            dog.Bark();
            dog.Eat();

            Puppy puppy = new Puppy();

            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            //Cat cat = new Cat();

            //cat.Eat();
            //cat.Meow();
        }
    }
}

