using System;
using System.Linq;

namespace p02.Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ").ToArray();
            string[] secondArray = Console.ReadLine().Split(" ").ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        Console.Write($"{secondArray[i]} ");
                    }
                }
            }
        }
    }
}
