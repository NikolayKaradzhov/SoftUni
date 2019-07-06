using System;
using System.Collections.Generic;
using System.Linq;

namespace p08.Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int givenNumber = int.Parse(Console.ReadLine());

            int[] printArray = new int[2];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == givenNumber)
                    {
                        printArray[0] = array[i];
                        printArray[1] = array[j];
                        Console.WriteLine(String.Join(" ", printArray));
                    }
                }
            }

        }
    }
}
