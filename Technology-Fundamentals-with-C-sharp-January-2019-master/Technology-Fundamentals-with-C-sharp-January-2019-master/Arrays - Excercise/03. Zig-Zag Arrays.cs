using System;
using System.Linq;

namespace p03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] readArray = new int[n];

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                readArray = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = readArray[0];
                    secondArray[i] = readArray[1];
                }
                if (i % 2 == 1)
                {
                    firstArray[i] = readArray[1];
                    secondArray[i] = readArray[0];
                }
            }

            // THE SAME AS string.Join

            //foreach (var index in firstArray)
            //{
            //    Console.Write(index + " ");
            //}
            //Console.WriteLine();
            // foreach (var index in secondArray)
            //{
            //    Console.Write(index + " ");
            //} 

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
