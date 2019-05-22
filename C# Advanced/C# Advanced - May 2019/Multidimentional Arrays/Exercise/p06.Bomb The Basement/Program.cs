using System;
using System.Linq;

namespace p06.Bomb_The_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = new int[rows][];

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = input[0];
            int targetCol = input[1];
            int radius = input[2];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[cols];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }

            int counterOfCols = 0;
            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] == 1)
                    {
                        counter++;
                        matrix[row][col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = 1;
                }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}