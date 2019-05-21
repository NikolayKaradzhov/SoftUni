using System;
using System.Linq;

namespace p06.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRowSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRowSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] numbersInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = numbersInput;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(" ");
                string command = tokens[0];

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int number = int.Parse(tokens[3]);

                if (row < 0
                    || row >= matrixRowSize
                    || col < 0
                    || col > matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (command == "Add")
                {
                    matrix[row][col] += number;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= number;
                }
                input = Console.ReadLine();
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}