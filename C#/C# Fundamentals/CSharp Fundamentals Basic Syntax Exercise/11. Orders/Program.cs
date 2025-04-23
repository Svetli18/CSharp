namespace Orders
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                decimal price = ((days * capsulesCount) * pricePerCapsule);
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");

            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}