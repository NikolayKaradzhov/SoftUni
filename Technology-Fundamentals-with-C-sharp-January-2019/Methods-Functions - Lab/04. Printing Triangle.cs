using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04.Print_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int readNumber = int.Parse(Console.ReadLine());
            ReadFirstPartOfTriangle(readNumber);
            ReadSecondPartOfTriangle(readNumber);
        }
        private static void ReadSecondPartOfTriangle(int readNumber)
        {
            for (int i = readNumber - 1; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        private static void ReadFirstPartOfTriangle(int readNumber)
        {
            for (int i = 1; i <= readNumber; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
