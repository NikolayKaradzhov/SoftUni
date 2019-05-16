using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            while(stack.Count > 1)
            {
                int firstOperand = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int secondOperand = int.Parse(stack.Pop());

                if (oper == "+")
                {
                    stack.Push((firstOperand + secondOperand).ToString());
                }
                else if (oper == "-")
                {
                    stack.Push((firstOperand - secondOperand).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
