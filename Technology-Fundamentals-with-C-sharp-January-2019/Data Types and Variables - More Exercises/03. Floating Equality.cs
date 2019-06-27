using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03.Floating Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            decimal secondNumber = decimal.Parse(Console.ReadLine());

            decimal precisionEps = 0.000001m;

            decimal differenceBetweenTheTwoNumbers = Math.Abs(firstNumber - secondNumber);

            if (differenceBetweenTheTwoNumbers < precisionEps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
