namespace RefactorVolumePyramid
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            double length, width, height = 0;
            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());
            //double area = (length * width) + (length * Math.Sqrt(Math.Pow(width / 2, 2) + Math.Pow(height, 2))) + (width * Math.Sqrt(Math.Pow(length / 2, 2) + Math.Pow(height, 2)));
            double area = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {area:f2}");

        }
    }
}