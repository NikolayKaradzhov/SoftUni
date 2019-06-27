using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                AddTwoNumbers(firstNumber, secondNumber);
            }
            else if (command == "multiply")
            {
                MultiplyTwoNumbers(firstNumber, secondNumber);
            }
            else if (command == "substract")
            {
                SubstractTwoNumbers(firstNumber, secondNumber);
            }
            else if (command == "divide")
            {
                DivideTwoNumbers(firstNumber, secondNumber);
            }
        }

        private static void DivideTwoNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }

        private static void SubstractTwoNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        private static void MultiplyTwoNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        private static void AddTwoNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}
