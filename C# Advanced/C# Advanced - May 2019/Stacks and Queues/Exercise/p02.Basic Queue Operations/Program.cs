using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine().Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            int elementsToEnqueue = input[0];
            int elementsToDequeue = input[1];
            int elementToCheckFor = input[2];

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int j = 0; j < elementsToDequeue; j++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToCheckFor))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}