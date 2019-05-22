using System;
using System.Linq;

namespace p02._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string pointA = string.Empty;
            string pointB = string.Empty;
            string pointC = string.Empty;
            string pointD = string.Empty;

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    pointA = matrix[row, col];
                    pointB = matrix[row, col + 1];
                    pointC = matrix[row + 1, col];
                    pointD = matrix[row + 1, col + 1];

                    if ((pointA == pointB) 
                        && (pointA == pointC)
                        && (pointA == pointD))
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
