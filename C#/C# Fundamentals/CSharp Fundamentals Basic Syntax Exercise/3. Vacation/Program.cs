namespace Vacation
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());

            string type = Console.ReadLine();

            string day = Console.ReadLine();

            decimal price = 0;

            if (type == "Students")
            {

                if (day == "Friday")
                {
                    if (30 <= cnt)
                    {
                        price = (cnt * 8.45m) * 0.85m;
                    }
                    else
                    {
                        price = cnt * 8.45m;
                    }
                }
                else if (day == "Saturday")
                {
                    if (30 <= cnt)
                    {
                        price = (cnt * 9.80m) * 0.85m;
                    }
                    else
                    {
                        price = cnt * 9.80m;
                    }
                }
                else if (day == "Sunday")
                {
                    if (30 <= cnt)
                    {
                        price = (cnt * 10.46m) * 0.85m;
                    }
                    else
                    {
                        price = cnt * 10.46m;
                    }
                }

            }
            else if (type == "Business")
            {

                if (day == "Friday")
                {
                    if (100 <= cnt)
                    {
                        cnt -= 10;
                    }

                    price = cnt * 10.90m;

                }
                else if (day == "Saturday")
                {
                    if (100 <= cnt)
                    {
                        cnt -= 10;
                    }

                    price = cnt * 15.60m;

                }
                else if (day == "Sunday")
                {
                    if (100 <= cnt)
                    {
                        cnt -= 10;
                    }

                    price = cnt * 16m;

                }

            }
            else if (type == "Regular")
            {

                if (day == "Friday")
                {

                    if (10 <= cnt && cnt <= 20)
                    {
                        price = (cnt * 15m) * 0.95m;
                    }
                    else
                    {
                        price = cnt * 15m;
                    }

                }
                else if (day == "Saturday")
                {

                    if (10 <= cnt && cnt <= 20)
                    {
                        price = (cnt * 20m) * 0.95m;
                    }
                    else
                    {
                        price = cnt * 20m;
                    }

                }
                else if (day == "Sunday")
                {

                    if (10 <= cnt && cnt <= 20)
                    {
                        price = (cnt * 22.50m) * 0.95m;
                    }
                    else
                    {
                        price = cnt * 22.50m;
                    }

                }

            }

            Console.WriteLine($"Total price: {price:f2}");

        }
    }
}