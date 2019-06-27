using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int quantityAllowedForOneTypeDecoration = int.Parse(Console.ReadLine());

            int daysLeftUntilChristmas = int.Parse(Console.ReadLine());

            decimal money = 0.0m;

            decimal christmasSpirit = 0.0m;

            decimal totalMoney = 0.0m;

            for (int day = 1; day <= daysLeftUntilChristmas; day++)
            {
                if (day % 11 == 0)
                {
                    quantityAllowedForOneTypeDecoration += 2;
                }
                if (day % 2 == 0)
                {
                    money = quantityAllowedForOneTypeDecoration * 2;
                    totalMoney += money;
                    christmasSpirit += 5;
                }
                if (day % 3 == 0)
                {
                    money = (quantityAllowedForOneTypeDecoration * 5)
                        + (quantityAllowedForOneTypeDecoration * 3);
                    totalMoney += money;
                    christmasSpirit += 13;
                }
                if (day % 5 == 0)
                {
                    money = quantityAllowedForOneTypeDecoration * 15;
                    totalMoney += money;
                    christmasSpirit += 17;
                }
                if (day % 3 == 0 && day % 5 == 0)
                {
                    christmasSpirit += 30;
                }
                if (day % 10 == 0)
                {
                    christmasSpirit -= 20;
                    money = 23;
                    totalMoney += money;
                    if (day == daysLeftUntilChristmas)
                    {
                        christmasSpirit -= 30;
                    }
                }
                
            }
            Console.WriteLine($"Total cost: {totalMoney:F0}");
            Console.WriteLine($"Total spirit: {christmasSpirit:F0}");
        }
    }
}
