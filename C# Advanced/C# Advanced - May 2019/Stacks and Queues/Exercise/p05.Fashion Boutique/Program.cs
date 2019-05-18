using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int totalCapacity = rackCapacity;
            int totalRacks = 1;

            Stack<int> stack = new Stack<int>(values);

            while (stack.Count > 0)
            {
                int currentClothes = stack.Pop();

                if (rackCapacity - currentClothes == 0)
                {
                    rackCapacity -= currentClothes;
                    rackCapacity = totalCapacity;
                    if (stack.Count > 0)
                    {
                        totalRacks++;
                    }
                }
                else if (rackCapacity - currentClothes < 0)
                {
                    totalRacks++;
                    rackCapacity = totalCapacity;
                    rackCapacity -= currentClothes;
                }
                else if (rackCapacity - currentClothes > 0)
                {
                    rackCapacity -= currentClothes;
                }
            }
            Console.WriteLine(totalRacks);
        }
    }
}