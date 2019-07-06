using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09.Greater_Of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetMax(input);
        }

        private static void GetMax(string input)
        {
            if (input == "int")
            {
                int biggerNum = 0;

                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                if (firstNum > secondNum)
                {
                    Console.WriteLine(firstNum);
                }
                else
                {
                    Console.WriteLine(secondNum);
                }
            }
            else if (input == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());

                if (firstChar > secondChar)
                {
                    Console.WriteLine(firstChar);
                }
                else
                {
                    Console.WriteLine(secondChar);
                }
            }
            else if (input == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();
                int result = firstString.CompareTo(secondString);

                if (result > 0)
                {
                    Console.WriteLine(firstString);
                }
                else
                {
                    Console.WriteLine(secondString);
                }
            }
        }
    }
}
