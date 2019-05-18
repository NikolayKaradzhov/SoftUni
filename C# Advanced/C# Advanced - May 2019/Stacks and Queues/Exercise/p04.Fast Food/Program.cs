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
                var currentOrder = queue.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    foodQuantity -= currentOrder;
                    queue.Dequeue();
                }
                else
                {
                    Console.Write($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }
            Console.WriteLine($"Orders complete");
        }
    }
}