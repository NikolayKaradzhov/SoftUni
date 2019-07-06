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
            int ageInput = int.Parse(Console.ReadLine());

            if (ageInput >= 0 && ageInput <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (ageInput >= 3 && ageInput <= 13)
            {
                Console.WriteLine("child");
            }
            else if (ageInput >= 14 && ageInput <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (ageInput >= 20 && ageInput <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (ageInput > 65)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
