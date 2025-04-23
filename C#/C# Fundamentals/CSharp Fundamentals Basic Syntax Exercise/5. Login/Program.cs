namespace Login
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            string password = new string(userName.Reverse().ToArray());

            int cnt = 1;
            string input;
            while ((input = Console.ReadLine()) != password)
            {
                if (cnt++ == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");

            }

            Console.WriteLine($"User {userName} logged in.");

        }
    }
}

