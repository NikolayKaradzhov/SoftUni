using System;
using System.Linq;

namespace p05.Snake_Moves
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

            string textInput = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //Example: SoftUni
                    //If counter == SoftUni.Length, start from S
                    if (counter >= textInput.Length)
                    {
                        counter = 0;
                    }
                    matrix[row, col] = textInput[counter++];
                }
            }
            //Print the snake
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}