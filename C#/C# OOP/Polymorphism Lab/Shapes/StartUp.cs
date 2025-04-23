namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(6.5, 10);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(rectangle.Draw());

            Shape circle = new Circle(12);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(circle.Draw());
        }
    }
}