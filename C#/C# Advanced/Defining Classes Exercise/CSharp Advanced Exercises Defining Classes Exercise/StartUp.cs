namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            Person person1 = new Person();

            Person person2 = new Person(5);

            Person person3 = new Person("Moni", 28);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
        }
    }
}