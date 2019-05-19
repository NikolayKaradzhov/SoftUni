using System;

namespace p04.Symbol_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRowsAndCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixRowsAndCols, matrixRowsAndCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string text = Console.ReadLine();
                int i = 0;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int j = i; j < text.Length;)
                    {
                        matrix[row, col] = text[j];
                        break;
                    }
                    i++;
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());

            int symbolRow = -1;
            int symbolCol = -1;
            bool isSymbolFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbolToFind)
                    {
                        symbolRow = i;
                        symbolCol = j;
                        isSymbolFound = true;
                    }
                    else
                    {
                        isSymbolFound = false;
                    }
                }
            }
            if (isSymbolFound)
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}