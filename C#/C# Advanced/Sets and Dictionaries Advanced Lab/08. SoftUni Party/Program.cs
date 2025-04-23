using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {

        var vipGuests = new HashSet<string>();
        var guests = new HashSet<string>();

        var peopleForCome = "";
        while ((peopleForCome = Console.ReadLine()) != "PARTY")
        {
            if (char.IsDigit(peopleForCome[0]))
            {
                vipGuests.Add(peopleForCome);
                continue;
            }

            guests.Add(peopleForCome);

        }

        var peopleWhoCome = "";
        while ((peopleWhoCome = Console.ReadLine()) != "END")
        {
            if (char.IsDigit(peopleWhoCome[0]))
            {
                vipGuests.Remove(peopleWhoCome);
                continue;
            }

            guests.Remove(peopleWhoCome);

        }

        Console.WriteLine($"{vipGuests.Count + guests.Count}");

        if (vipGuests.Any())
        {
            Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
        }

        if (guests.Any())
        {
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}