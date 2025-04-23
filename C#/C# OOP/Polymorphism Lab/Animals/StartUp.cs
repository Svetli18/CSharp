namespace Animals
{
    using Operations.IO;
    using Operations.IO.Contracts;
    
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new Writer();

            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            writer.WriteLine(cat.ExplainSelf());
            writer.WriteLine(dog.ExplainSelf());
        }
    }
}