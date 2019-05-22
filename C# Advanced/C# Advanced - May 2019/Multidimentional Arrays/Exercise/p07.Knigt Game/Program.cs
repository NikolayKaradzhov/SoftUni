using System;
using System.Linq;

namespace p07.Knigt_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currentCount = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxCount == 0)
                {
                    break;
                }

                matrix[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] matrix, int desiredRow, int desiredCol)
        {
           return desiredRow < matrix.GetLength(0) && desiredRow >= 0
                && desiredCol < matrix.GetLength(1) && desiredCol >= 0;
        }
    }
}