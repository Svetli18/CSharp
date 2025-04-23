namespace PadawanEquipment
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            decimal priceForLightsaber = decimal.Parse(Console.ReadLine());
            decimal priceForRobe = decimal.Parse(Console.ReadLine());
            decimal priceForBelt = decimal.Parse(Console.ReadLine());

            int freeBelts = countOfStudents / 6;
            decimal totalSabersPrice = priceForLightsaber * Math.Ceiling(countOfStudents * 1.1m);
            decimal totalRobesPrice = priceForRobe * countOfStudents;
            decimal totalBeltsPrice = priceForBelt * (countOfStudents - freeBelts);

            decimal totalEquipmentPrice = (totalSabersPrice + totalRobesPrice + totalBeltsPrice);

            if (totalEquipmentPrice <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalEquipmentPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalEquipmentPrice - amountOfMoney:f2}lv more.");
            }
        }
    }
}