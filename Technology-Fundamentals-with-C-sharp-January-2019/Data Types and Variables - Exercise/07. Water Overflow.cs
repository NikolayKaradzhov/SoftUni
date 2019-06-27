using System;

namespace p07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentCapacity = 0;
            int capacity = 0;

            for (int i = 0; i < n; i++)
            {
                currentCapacity = int.Parse(Console.ReadLine());
                capacity += currentCapacity;

                if (capacity > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    capacity -= currentCapacity;
                }
            }
            Console.WriteLine($"{capacity}");
        }
    }
}
