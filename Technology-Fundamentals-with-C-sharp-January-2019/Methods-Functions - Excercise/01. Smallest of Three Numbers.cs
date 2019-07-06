using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01.Smalles_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            CompareThreeNumbers(firstNumber, secondNumber, thirdNumber);
        }

        private static void CompareThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
            {
                Console.WriteLine(secondNumber);
            }
            else if (thirdNumber <= firstNumber && thirdNumber <= secondNumber)
            {
                Console.WriteLine(thirdNumber);
            }
        }
    }
}
