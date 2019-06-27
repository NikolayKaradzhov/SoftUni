using System;
using System.Linq;

namespace p01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] peopleCount = new int[n];

            int sumPeople = 0;

            for (int i = 0; i < n; i++)
            {
                peopleCount[i] = int.Parse(Console.ReadLine());

                sumPeople += peopleCount[i];
            }

            for (int j = 0; j < n; j++)
            {
                Console.Write(peopleCount[j] + " ");
            }
            Console.WriteLine();
            Console.Write(sumPeople);
        }
    }
}
