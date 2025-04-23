namespace SpiceMustFlow
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int spiceExtract = int.Parse(Console.ReadLine());

            int totalAmountSpiceExtracted = 0;
            int daysCount = 0;

            while (100 <= spiceExtract)
            {
                totalAmountSpiceExtracted += spiceExtract;
                daysCount++;

                spiceExtract -= 10;
                totalAmountSpiceExtracted -= 26;
            }

            if (26 <= totalAmountSpiceExtracted)
            {
                totalAmountSpiceExtracted -= 26;
            }

            Console.WriteLine(daysCount);
            Console.WriteLine(totalAmountSpiceExtracted);

        }
    }
}