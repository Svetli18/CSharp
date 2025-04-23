namespace RageExpenses
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int lostGamesCnt = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int smashesHeadsetCnt = 0;
            int smashesMouseCnt = 0;
            int smashesKeyboardCnt = 0;
            int smashesDisplayCnt = 0;

            int cntForDisplay = 0;
            int cnt = 1;

            while (cnt <= lostGamesCnt)
            {
                int cntForKeyboard = 0;
                
                if (cnt % 2 == 0)
                {
                    smashesHeadsetCnt++;
                    cntForKeyboard++;
                }

                if (cnt % 3 == 0)
                {
                    smashesMouseCnt++;
                    cntForKeyboard++;
                }

                if (cntForKeyboard == 2)
                {
                    smashesKeyboardCnt++;
                    cntForDisplay++;
                }

                if (cntForDisplay == 2)
                {
                    smashesDisplayCnt++;
                    cntForDisplay = 0;
                }

                cnt++;

            }

            decimal totalRageExpenses = 0;

            if (0 < smashesHeadsetCnt)
            {
                totalRageExpenses += smashesHeadsetCnt * headsetPrice;
            }

            if (0 < smashesMouseCnt)
            {
                totalRageExpenses += smashesMouseCnt * mousePrice;
            }

            if (0 < smashesKeyboardCnt)
            {
                totalRageExpenses += smashesKeyboardCnt * keyboardPrice;
            }

            if (0 < smashesDisplayCnt)
            {
                totalRageExpenses += smashesDisplayCnt * displayPrice;
            }

            Console.WriteLine($"Rage expenses: {totalRageExpenses:f2} lv.");

        }
    }
}
