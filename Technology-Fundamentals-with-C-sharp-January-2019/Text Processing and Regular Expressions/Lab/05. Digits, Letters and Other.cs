using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p05.Digits_Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (var item in input)
            {
                if (Char.IsDigit(item))
                {
                    int index = input.IndexOf(item);
                    Console.Write(item);
                    input = input.Remove(index, 1);
                }
                else
                {
                    continue;
                }  
            }

            Console.WriteLine();

            foreach (var item in input)
            {
                if (Char.IsLetter(item))
                {
                    int index = input.IndexOf(item);
                    Console.Write(item);
                    input = input.Remove(index, 1);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write(item);
            }
        }
    }
}
