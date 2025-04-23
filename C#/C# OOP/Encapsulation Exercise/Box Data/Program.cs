namespace BoxData
{
    using System;

    public class Program
    {
        public static void Main()
        {

            var h = 245 * 0.4;

            Console.WriteLine(h);

            try
            {
                double lateral = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lateral, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}