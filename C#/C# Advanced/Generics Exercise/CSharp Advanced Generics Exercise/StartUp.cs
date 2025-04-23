namespace GenericBox
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            var element = Console.ReadLine();



            Console.WriteLine(box);
        }
    }
}