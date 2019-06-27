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
            int input = int.Parse(Console.ReadLine());

            if (input % 10 == 1)
            {
                Console.WriteLine("one");
            }
            else if (input % 10 == 2)
            {
                Console.WriteLine("two");
            }
            else if (input % 10 == 3)
            {
                Console.WriteLine("three");
            }
            else if (input % 10 == 4)
            {
                Console.WriteLine("four");
            }
            else if (input % 10 == 5)
            {
                Console.WriteLine("five");
            }
            else if (input % 10 == 6)
            {
                Console.WriteLine("six");
            }
            else if (input % 10 == 7)
            {
                Console.WriteLine("seven");
            }
            else if (input % 10 == 8)
            {
                Console.WriteLine("eight");
            }
            else if (input % 10 == 9)
            {
                Console.WriteLine("");
            }
            else if (input % 10 == 0)
            {
                Console.WriteLine("zero");
            }
        }
    }
}
