using System;

namespace p02.Tron_Racers
{
    class Program
    {
        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;

        static char[][] matrix;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            matrix = new char[matrixSize][];

            FillMatrix();
            
            while (true)
            {
                string[] directions = Console.ReadLine()
                    .Split(" ");

                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];

                //FirstPlayerMoves
                if (firstPlayerDirection == "down")
                {
                    firstPlayerRow++;

                    if (firstPlayerRow == matrix.Length)
                    {
                        firstPlayerRow = 0;
                    }
                }
                else if (firstPlayerDirection == "up")
                {
                    firstPlayerRow--;

                    if (firstPlayerRow < 0)
                    {
                        firstPlayerRow = matrix.Length - 1;
                    }
                }
                else if (firstPlayerDirection == "left")
                {
                    firstPlayerCol--;

                    if (firstPlayerCol < 0)
                    {
                        firstPlayerCol = matrix[firstPlayerRow].Length - 1;
                    }
                }
                else if (firstPlayerDirection == "right")
                {
                    firstPlayerCol++;

                    if (firstPlayerCol == matrix[firstPlayerRow].Length)
                    {
                        firstPlayerCol = 0;
                    }
                }

                if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'x';
                    EndProgramAndPrintMatrix();
                }
                else
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'f';
                }

                //Second Player Moves

                if (secondPlayerDirection == "down")
                {
                    secondPlayerRow++;

                    if (secondPlayerRow == matrix.Length)
                    {
                        secondPlayerRow = 0;
                    }
                }
                else if (secondPlayerDirection == "up")
                {
                    secondPlayerRow--;

                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = matrix.Length - 1;
                    }
                }
                else if (secondPlayerDirection == "left")
                {
                    secondPlayerCol--;

                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = matrix[secondPlayerRow].Length - 1;
                    }
                }
                else if (secondPlayerDirection == "right")
                {
                    secondPlayerCol++;

                    if (secondPlayerCol == matrix[secondPlayerRow].Length)
                    {
                        secondPlayerCol = 0;
                    }
                }

                if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 'x';
                    EndProgramAndPrintMatrix();
                }
                else
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 's';
                }
            }
        }

        private static void EndProgramAndPrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];

                    //check for the position of both players
                    if (matrix[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    if (matrix[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}