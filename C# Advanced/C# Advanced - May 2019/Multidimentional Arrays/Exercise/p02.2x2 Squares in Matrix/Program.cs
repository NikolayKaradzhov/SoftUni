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

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] text = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                }
            }
        }
    }
}
