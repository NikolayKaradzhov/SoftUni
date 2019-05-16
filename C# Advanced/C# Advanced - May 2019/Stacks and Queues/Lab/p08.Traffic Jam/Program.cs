using System;
using System.Collections.Generic;

namespace p08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> queue = new Queue<string>();

            int passedCarsCounter = 0;
            int currentCount = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    if (queue.Count > n)
                    {
                        currentCount = n;
                    }
                    else
                    {
                        currentCount = queue.Count;
                    }
                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        passedCarsCounter++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
        }
    }
}