using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01.Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumberSign(int.Parse(Console.ReadLine()));
        }

        static void PrintNumberSign(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
