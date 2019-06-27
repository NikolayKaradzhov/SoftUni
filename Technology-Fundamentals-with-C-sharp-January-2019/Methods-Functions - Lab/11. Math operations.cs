using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10.Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string oper = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

          double result = Calculate(firstNumber, oper, secondNumber);
            Console.WriteLine(Math.Round(result));
        }

        private static double Calculate(int firstNumber, string oper, int secondNumber)
        {
            double result = 0;

            if (oper == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (oper == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (oper == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (oper == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }
    }
}
