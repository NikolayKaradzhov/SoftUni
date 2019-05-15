using System;
using System.Collections.Generic;

namespace p01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> stack = new Stack<string>();

            foreach (var item in input)
            {
                stack.Push(item.ToString());
            }

            foreach (var word in stack)
            {
                Console.Write(word);
            }
            Console.WriteLine();
        }
    }
}