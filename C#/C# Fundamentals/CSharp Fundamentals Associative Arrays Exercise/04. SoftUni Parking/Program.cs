using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, string> parking = new Dictionary<string, string>();

        for (int i = 0; i < n; i++)
        {
            string[] currCmd = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = currCmd[0];
            string username = currCmd[1];
            
            if (command == "register")
            {
                string licensePlateNumber = currCmd[2];

                if (parking.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    continue;
                }

                parking[username] = licensePlateNumber;

                Console.WriteLine($"{username} registered {licensePlateNumber} successfully");

            }
            else if (command == "unregister")
            {
                if (!parking.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                    continue;
                }

                parking.Remove(username);

                Console.WriteLine($"{username} unregistered successfully");

            }
        }

        foreach (var kvp in parking)
        {
            Console.WriteLine($"{kvp.Key} => {kvp.Value}");
        }

    }
}