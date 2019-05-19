using System;
using System.Linq;

namespace p02.Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0],input[1]];
            int sumOfCurrentCol = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            //Calculate sum of columns
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                sumOfCurrentCol = 0;
                
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sumOfCurrentCol += matrix[rows, cols];
                }
                Console.WriteLine(sumOfCurrentCol);
            }
        }
    }
}