using System;
using System.Linq;

namespace _05._Date_Modifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] date1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int year1 = date1[0];
            int month1 = date1[1];
            int day1 = date1[2];


            int[] date2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int year2 = date2[0];
            int month2 = date2[1];
            int day2 = date2[2];

            DateModifier dateModifier = new DateModifier(day1, month1, year1, day2, month2, year2);

            Console.WriteLine(dateModifier.DaysBetweenTwoDates());

        }
    }
}
