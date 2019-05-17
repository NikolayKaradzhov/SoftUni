using System;
using System.Collections.Generic;
using System.Linq;

namespace p04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orderQuantity = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orderQuantity);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (foodQuantity < queue.Peek())
                {
                    break;
                }
                else
                {
                    foodQuantity -= queue.Dequeue();
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (queue.Count() != 0)
                {
                    Console.WriteLine($"Orders left: {queue.Dequeue()}");
                }
            }
        }
    }
}