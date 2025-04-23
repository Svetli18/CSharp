using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var parking = new HashSet<string>();

        Regex regex = new Regex(@"\b[A-Z]{2}[0-9]{4}[A-Z]{2}\b");

        var command = "";
        while ((command = Console.ReadLine()) != "END")
        {
            var commArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var comm = commArgs[0];
            var number = commArgs[1];

            Match match = regex.Match(number);


            if (comm == "IN" && match.Success)
            {
                parking.Add(match.Value);
            }
            else if (comm == "OUT" && match.Success)
            {
                parking.Remove(match.Value);
            }
        }


        if (parking.Any())
        {
            Console.WriteLine(string.Join(Environment.NewLine, parking));
        }
        else
        {
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}