using System;
using System.Globalization;

class TriangleOfNumbers
{
    static void Main()
    {
        int lostGamesCount = int.Parse(Console.ReadLine());
        double headsetPrice = double.Parse(Console.ReadLine());
        double mousePrice = double.Parse(Console.ReadLine());
        double keyboardPrice = double.Parse(Console.ReadLine());
        double displayPrice = double.Parse(Console.ReadLine());

        int trashedHeadsetTimes = 0;
        int trashedMouseTimes = 0;
        int trashedKeyboardTimes = 0;
        int trashedDisplayTimes = 0;

        double rageExpenseMouse = 0.0;
        double rageExpenseKeyBoard = 0.0;
        double rageExpenseHeadseat = 0.0;
        double rageExpenseDisplay = 0.0;

        for (int currentGame = 1; currentGame <= lostGamesCount; currentGame++)
        {
            if (currentGame % 2 == 0)
            {
                trashedHeadsetTimes++;
            }
            if (currentGame % 3 == 0)
            {   
                trashedMouseTimes++;
            }
            if (currentGame % 6 == 0)
            {
                trashedKeyboardTimes++;
            }
            if (currentGame % 12 == 0)
            {
                trashedDisplayTimes++;
            }
        }
        rageExpenseHeadseat = (double)trashedHeadsetTimes * headsetPrice;
        rageExpenseMouse = (double)trashedMouseTimes * mousePrice;
        rageExpenseKeyBoard = (double)trashedKeyboardTimes * keyboardPrice;
        rageExpenseDisplay = (double)trashedDisplayTimes * displayPrice;

        double totalRageExpenses = rageExpenseDisplay
                + rageExpenseHeadseat
                + rageExpenseKeyBoard
                + rageExpenseMouse;
            Console.WriteLine($"Rage expenses: {totalRageExpenses:f2} lv.");
    }
}
