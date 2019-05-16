using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] checkElementsInStack = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] stackElements = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            int elementsToPush = checkElementsInStack[0];
            int elementsToPop = checkElementsInStack[1];
            int numberToCheckIfContains = checkElementsInStack[2];
            int minNumber = int.MaxValue;

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(stackElements[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numberToCheckIfContains))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                foreach (var element in stack)
                {
                    if (element < minNumber)
                    {
                        minNumber = element;
                    }
                }
                Console.WriteLine(minNumber);
            }
        }
    }
}