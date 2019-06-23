using System;

namespace p02
{
    class Program
    {
        static char[][] matrix;

        static int stephenPositionRow;
        static int stephenPositionCol;

        static int firstBlackHoleRow = -1;
        static int firstBlackHoleCol = -1;

        static int secondBlackHoleRow;
        static int secondBlackHoleCol;

        static string command;

        static int energyCollected;
        static string currentChar;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            matrix = new char[matrixSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'S')
                    {
                        stephenPositionRow = row;
                        stephenPositionCol = col;
                    }
                    else if (matrix[row][col] == 'O' && firstBlackHoleRow == -1 && firstBlackHoleCol == -1)
                    {
                        firstBlackHoleRow = row;
                        firstBlackHoleCol = col;
                    }
                    else if (matrix[row][col] == 'O' && firstBlackHoleRow != -1 && firstBlackHoleCol != -1)
                    {
                        secondBlackHoleRow = row;
                        secondBlackHoleCol = col;
                    }
                }
            }

            MoveStephen();

            if (energyCollected >= 50)
            {
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {energyCollected}");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {energyCollected}");
            }

            //printMatrix

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }
        private static void MoveStephen()
        {
            while (true)
            {
                command = Console.ReadLine();

                if (stephenPositionRow > matrix.Length - 1
                || stephenPositionRow < 0
                || stephenPositionCol < 0
                || stephenPositionCol > matrix[stephenPositionRow].Length - 1)
                {
                    break;
                }
                else
                {
                    if (command == "up")
                    {
                        stephenPositionRow--;

                        matrix[stephenPositionRow + 1][stephenPositionCol] = '-';


                        if (stephenPositionRow > matrix.Length - 1
                || stephenPositionRow < 0
                || stephenPositionCol < 0
                || stephenPositionCol > matrix[stephenPositionRow].Length - 1)
                        {
                            break;
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] != 'O' 
                            && matrix[stephenPositionRow][stephenPositionCol] != '-')
                        {
                            currentChar = matrix[stephenPositionRow][stephenPositionCol].ToString();

                            int.TryParse(currentChar, out int energy);

                            energyCollected += energy;

                            matrix[stephenPositionRow][stephenPositionCol] = 'S';
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] == 'O')
                        {
                            stephenPositionRow = secondBlackHoleRow;
                            stephenPositionCol = secondBlackHoleCol;

                            matrix[firstBlackHoleRow][firstBlackHoleCol] = '-';
                            matrix[secondBlackHoleRow][secondBlackHoleCol] = '-';

                        }
                    }
                    else if (command == "down")
                    {
                        stephenPositionRow++;

                        matrix[stephenPositionRow - 1][stephenPositionCol] = '-';

                        if (stephenPositionRow > matrix.Length - 1
                || stephenPositionRow < 0
                || stephenPositionCol < 0
                || stephenPositionCol > matrix[stephenPositionRow].Length - 1)
                        {
                            break;
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] != 'O' 
                            && matrix[stephenPositionRow][stephenPositionCol] != '-')
                        {
                            currentChar = matrix[stephenPositionRow][stephenPositionCol].ToString();

                            int.TryParse(currentChar, out int energy);

                            energyCollected += energy;

                            matrix[stephenPositionRow][stephenPositionCol] = 'S';
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] == 'O')
                        {
                            stephenPositionRow = secondBlackHoleRow;
                            stephenPositionCol = secondBlackHoleCol;

                            matrix[firstBlackHoleRow][firstBlackHoleCol] = '-';
                            matrix[secondBlackHoleRow][secondBlackHoleCol] = '-';
                        }
                    }
                    else if (command == "left")
                    {
                        stephenPositionCol--;

                        matrix[stephenPositionRow][stephenPositionCol + 1] = '-';

                        if (stephenPositionRow > matrix.Length - 1
                || stephenPositionRow < 0
                || stephenPositionCol < 0
                || stephenPositionCol > matrix[stephenPositionRow].Length - 1)
                        {
                            break;
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] != 'O' 
                            && matrix[stephenPositionRow][stephenPositionCol] != '-')
                        {
                            currentChar = matrix[stephenPositionRow][stephenPositionCol].ToString();

                            int.TryParse(currentChar, out int energy);

                            energyCollected += energy;

                            matrix[stephenPositionRow][stephenPositionCol] = 'S';
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] == 'O')
                        {
                            stephenPositionRow = secondBlackHoleRow;
                            stephenPositionCol = secondBlackHoleCol;

                            matrix[firstBlackHoleRow][firstBlackHoleCol] = '-';
                            matrix[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        }
                    }
                    else if (command == "right")
                    {
                        stephenPositionCol++;

                        matrix[stephenPositionRow][stephenPositionCol - 1] = '-';

                        if (stephenPositionRow > matrix.Length - 1
                || stephenPositionRow < 0
                || stephenPositionCol < 0
                || stephenPositionCol > matrix[stephenPositionRow].Length - 1)
                        {
                            break;
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] != 'O' 
                            && matrix[stephenPositionRow][stephenPositionCol] != '-')
                        {
                            currentChar = matrix[stephenPositionRow][stephenPositionCol].ToString();

                            int.TryParse(currentChar, out int energy);

                            energyCollected += energy;

                            matrix[stephenPositionRow][stephenPositionCol] = 'S';
                        }
                        else if (matrix[stephenPositionRow][stephenPositionCol] == 'O')
                        {
                            stephenPositionRow = secondBlackHoleRow;
                            stephenPositionCol = secondBlackHoleCol;

                            matrix[firstBlackHoleRow][firstBlackHoleCol] = '-';
                            matrix[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        }
                    }
                }

                if (energyCollected >= 50)
                {
                    break;
                }
            }
        }
    }
}