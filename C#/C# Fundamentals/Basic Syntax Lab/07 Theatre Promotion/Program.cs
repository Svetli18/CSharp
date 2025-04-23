using System;

public class Program
{
    private static void Main(string[] args)
    {
        string day = Console.ReadLine();

        int age = int.Parse(Console.ReadLine());

        int ticketPrice = 0;

        if (0 <= age && age <= 18)
        {
            if (day == "Weekday")
            {
                ticketPrice = 12;
            }
            else if (day == "Weekend")
            {
                ticketPrice = 15;
            }
            else if (day == "Holiday")
            {
                ticketPrice = 5;
            }
        }
        else if (19 <= age && age <= 64)
        {
            if (day == "Weekday")
            {
                ticketPrice = 18;
            }
            else if (day == "Weekend")
            {
                ticketPrice = 20;
            }
            else if (day == "Holiday")
            {
                ticketPrice = 12;
            }
        }
        else if (65 <= age && age <= 122)
        {
            if (day == "Weekday")
            {
                ticketPrice = 12;
            }
            else if (day == "Weekend")
            {
                ticketPrice = 15;
            }
            else if (day == "Holiday")
            {
                ticketPrice = 10;
            }
        }
        else
        {
            Console.WriteLine("Error!");
            return;
        }

        Console.WriteLine($"{ticketPrice}$");
    }

}