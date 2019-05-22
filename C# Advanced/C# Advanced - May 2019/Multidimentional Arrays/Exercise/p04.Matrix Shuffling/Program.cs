using System;
using System.Linq;

namespace p04.Matrix_Shuffling
{
    class Program
    {
       public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string swapCommand = tokens[0];

                if (swapCommand != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRowSwap = int.Parse(tokens[1]);
                int firstColSwap = int.Parse(tokens[2]);

                int secondRowSwap = int.Parse(tokens[3]);
                int secondColSwap = int.Parse(tokens[4]);

                bool allColumnsAreValid = (firstRowSwap >= 0 && firstRowSwap < matrix.GetLength(0))
                                       && (firstColSwap >= 0 && firstColSwap < matrix.GetLength(1))
                                       && (secondColSwap >= 0 && secondColSwap < matrix.GetLength(1))
                                       && (firstRowSwap >= 0 && firstRowSwap < matrix.GetLength(0));

                if (swapCommand == "swap" && allColumnsAreValid && tokens.Length == 5)
                {
                    string firstTextToSwap = matrix[firstRowSwap, firstColSwap];
                    string secondTextToSwap = matrix[secondRowSwap, secondColSwap];

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (row == firstRowSwap && col == firstColSwap)
                            {
                                matrix[row, col] = secondTextToSwap;
                            }
                            if (row == secondRowSwap && col == secondColSwap)
                            {
                                matrix[row, col] = firstTextToSwap;
                            }
                        }
                    }

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}