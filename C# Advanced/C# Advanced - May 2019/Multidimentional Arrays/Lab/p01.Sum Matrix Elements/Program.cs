using System;
using System.Linq;

namespace p01.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixTotalSum = 0;

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0],input[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = tokens[cols];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixTotalSum += matrix[i, j];
                }
            }
            Console.WriteLine(matrixTotalSum);
        }
    }
}