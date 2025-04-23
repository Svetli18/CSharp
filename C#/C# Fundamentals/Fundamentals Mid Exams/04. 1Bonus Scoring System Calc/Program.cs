using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        int lecturesCount = int.Parse(Console.ReadLine());
        int bonus = int.Parse(Console.ReadLine());

        double maxBonus = double.MinValue;
        int bestStudent = 0;

        double calc = (lecturesCount * (studentsCount + bonus));

        for (int i = 0; i < studentsCount; i++)
        {
            double studentAttendances = int.Parse(Console.ReadLine());

            double currentBonus = studentAttendances / lecturesCount * (5 + bonus);

        }

    }
}