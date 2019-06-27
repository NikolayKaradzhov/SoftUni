using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05.Multiply_Big_Numbers
{
    class MultiplyBigNumbersProgram
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            string secondNumber = Console.ReadLine().TrimStart(new char[] { '0' });

            if (secondNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            byte sum = 0;
            byte numberInMind = 0;
            byte remainder = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {     
                for (int j = secondNumber.Length - 1; j >= 0; j--)
                {
                    sum = (byte)(byte.Parse(firstNumber[i].ToString()) * byte.Parse(secondNumber[j].ToString()) + numberInMind);
                    numberInMind = (byte)(sum / 10);
                    remainder = (byte)(sum % 10);
                    result.Append(remainder);
                    if (i == 0 && numberInMind != 0)
                    {
                        result.Append(numberInMind);
                    }
                }
            }
            char[] resultToChar = result.ToString().ToCharArray();
            Array.Reverse(resultToChar);
            Console.WriteLine(new string(resultToChar));
        }
    }
}
