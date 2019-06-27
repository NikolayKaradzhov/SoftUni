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
            decimal studentsCount = decimal.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            decimal totalPrice = 0.0m;
            decimal currentDayPrice = 0.0m;

            if (dayOfWeek.Equals("Friday", StringComparison.InvariantCultureIgnoreCase))
            {
                if (typeOfGroup.Equals("Students", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 8.45m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Business", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 10.90m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Regular", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 15.00m;
                    totalPrice = studentsCount * currentDayPrice;
                }
            }
            else if (dayOfWeek.Equals("Saturday", StringComparison.InvariantCultureIgnoreCase))
            {
                if (typeOfGroup.Equals("Students", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 9.80m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Business", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 15.60m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Regular", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 20.00m;
                    totalPrice = studentsCount * currentDayPrice;
                }
            }
            else if (dayOfWeek.Equals("Sunday", StringComparison.InvariantCultureIgnoreCase))
            {
                if (typeOfGroup.Equals("Students", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 10.46m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Business", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 16.00m;
                    totalPrice = studentsCount * currentDayPrice;
                }
                else if (typeOfGroup.Equals("Regular", StringComparison.InvariantCultureIgnoreCase))
                {
                    currentDayPrice = 22.50m;
                    totalPrice = studentsCount * currentDayPrice;
                }
            }

            if (typeOfGroup.Equals("Students", StringComparison.InvariantCultureIgnoreCase) 
                && studentsCount >= 30)
            {
                totalPrice -= totalPrice * 0.15m;
            }
            else if (typeOfGroup.Equals("Business", StringComparison.InvariantCultureIgnoreCase)
                && studentsCount >= 100)   
            {
                totalPrice -= (10 * currentDayPrice);
            }
            else if (typeOfGroup.Equals("Regular", StringComparison.InvariantCultureIgnoreCase)
                && (studentsCount >= 10 && studentsCount <= 20))
            {
                totalPrice -= totalPrice * 0.05m;
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
