using System;
using System.Linq;

namespace p05.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] 
                        + matrix[row, col + 1] 
                        + matrix[row + 1, col] 
                        + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedCol = col;
                        selectedRow = row;
                    }
                }
            }
            Console.WriteLine($"{matrix[selectedRow, selectedCol]} " 
                + $"{matrix[selectedRow, selectedCol + 1]}\n"
                + $"{matrix[selectedRow + 1, selectedCol]} "
                + $"{matrix[selectedRow + 1, selectedCol + 1]}\n{maxSum}");
        }
    }
}