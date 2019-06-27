using System;
using System.Linq;

namespace p07.Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumOfArray = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            for (int j = 0; j < firstArray.Length; j++)
            {
                if (firstArray[j] == secondArray[j])
                {
                    sumOfArray += firstArray[j];
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sumOfArray}");
        }
    }
}
