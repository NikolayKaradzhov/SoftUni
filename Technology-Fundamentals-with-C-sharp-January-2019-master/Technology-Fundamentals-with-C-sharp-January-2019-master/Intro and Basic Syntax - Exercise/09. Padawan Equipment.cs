using System;
using System.Globalization;

class TriangleOfNumbers
{
    static void Main()
    {
        double amountOfMoneyIvanChoHas = double.Parse(Console.ReadLine());
        int studentsCount = int.Parse(Console.ReadLine());

        double lightSabrePrice = double.Parse(Console.ReadLine());
        double robesPrice = double.Parse(Console.ReadLine());
        double beltPrice = double.Parse(Console.ReadLine());

        double lightSabre10PercentMore = Math.Ceiling((studentsCount * 0.10) + studentsCount);
        double lightSabreTotalPrice = lightSabrePrice * lightSabre10PercentMore;
        double robesTotalPrice = robesPrice * studentsCount;
        double freeBelts = Math.Floor(studentsCount / 6.0);
        double beltsTotalPrice = (studentsCount - freeBelts) * beltPrice;

        double totalPriceAll = lightSabreTotalPrice + robesTotalPrice + beltsTotalPrice;

        double neededMoney = 0.0;

        if (amountOfMoneyIvanChoHas >= totalPriceAll)
        {
            Console.WriteLine($"The money is enough - it would cost {totalPriceAll:F2}lv.");
        }
        else if (totalPriceAll > amountOfMoneyIvanChoHas)
        {
            neededMoney = totalPriceAll - amountOfMoneyIvanChoHas;
            Console.WriteLine($"Ivan Cho will need {neededMoney:F2}lv more.");
        }

    }
}
