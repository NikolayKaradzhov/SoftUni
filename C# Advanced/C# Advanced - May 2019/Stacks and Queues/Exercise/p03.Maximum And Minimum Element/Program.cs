using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Maximum_And_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int queryCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queryCount; i++)
            {
                string query = Console.ReadLine();

                if (query.Contains(' '))
                {
                    string[] tokens = query.Split();

                    int elementToPush = int.Parse(tokens[1]);

                    stack.Push(elementToPush);
                }
                else
                {
                    if (query == "2" && stack.Count != 0)
                    {
                        stack.Pop();
                    }
                    else if (query == "3" && stack.Count != 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (query == "4" && stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            while (stack.Count != 0)
            {
                if (stack.Count == 1)
                {
                    Console.Write(stack.Pop());
                }
                else
                {
                    Console.Write($"{stack.Pop()}, ");
                }
            }
        }
    }
}