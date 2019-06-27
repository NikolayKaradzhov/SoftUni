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
            int typingRows = int.Parse(Console.ReadLine());
         
            int numberOfDigits = 0;

            string message = string.Empty;            

            for (int i = 1; i <= typingRows; i++)
            {
                int n = int.Parse(Console.ReadLine());

                numberOfDigits = n.ToString().Length;

                int mainDigit = n % 10;
                int offsetOfTheNumber = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9) 
                {
                    offsetOfTheNumber++;
                }
                int letterIndex = offsetOfTheNumber + numberOfDigits - 1;

                if (mainDigit != 0)
                {
                    message += (char)(letterIndex + 97);
                }
                else
                {
                    message += (char)(32);
                }
            }
            Console.WriteLine(message);
        }
    }
}
