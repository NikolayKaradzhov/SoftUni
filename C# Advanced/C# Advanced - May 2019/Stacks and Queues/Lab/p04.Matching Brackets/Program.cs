using System;
using System.Collections.Generic;
using System.Text;

namespace p04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>(); 

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int indexOfLastParenthesis = stack.Pop();
                    Console.WriteLine(input.Substring(indexOfLastParenthesis, i - indexOfLastParenthesis + 1));
                }
            }
        }
    }
}
