using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                var currentNumber = inputNumbers[i];

                if (currentNumber % 2 == 0)
                {
                    if (i == inputNumbers.Length - 1)
                    {
                        queue.Enqueue(currentNumber);
                        Console.WriteLine(queue.Peek());
                        break;
                    }
                    queue.Enqueue(currentNumber);
                    Console.Write($"{queue.Peek()}, ");
                    queue.Dequeue();
                }
            }
        }
    }
}