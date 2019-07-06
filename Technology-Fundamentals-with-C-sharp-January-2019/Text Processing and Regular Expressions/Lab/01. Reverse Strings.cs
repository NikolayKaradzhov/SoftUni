using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            while (input != "end")
            {
                string reversedWord = string.Empty;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedWord += input[i];
                }
                Console.WriteLine($"{input} = {reversedWord}");

                input = Console.ReadLine();
            }
        }
    }
}
