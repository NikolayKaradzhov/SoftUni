using System;

namespace HelensAbduction
{
    class Program
    {
        static char[][] matrix;

        static int parisRow;
        static int parisCol;

        static bool won = false;

        static void Main(string[] args)
        {
            int parisEnergy = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            matrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            while (parisEnergy > 0)
            {
                string[] commands = Console.ReadLine().Split();

                string direction = commands[0];

                Int32.TryParse(commands[1], out int spartanSpawnRow);
                Int32.TryParse(commands[2], out int spartanSpawnCol);

                matrix[spartanSpawnRow][spartanSpawnCol] = 'S';

                matrix[parisRow][parisCol] = '-';

                if (direction == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (parisRow + 1 < matrix.Length)
                    {
                        parisRow++;
                    }
                }
                else if (direction == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol--;
                    }
                }
                else if (direction == "right")
                {
                    if (parisCol + 1 < matrix[parisRow].Length)
                    {
                        parisCol++;
                    }
                }

                parisEnergy--;

                char symbolOnNextStep = matrix[parisRow][parisCol];

                if (symbolOnNextStep == 'S')
                {
                    parisEnergy -= 2;
                    matrix[parisRow][parisCol] = '-';
                }
                else if (symbolOnNextStep == 'H')
                {
                    won = true;
                    matrix[parisRow][parisCol] = '-';
                    break;
                }
                else if (symbolOnNextStep == '-')
                {
                    matrix[parisRow][parisCol] = 'P';
                }

                if (parisEnergy <= 0)
                {
                    matrix[parisRow][parisCol] = 'X';
                    break;
                }        
            }

            if (won)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            //PrintMatrix
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] currentRow = matrix[row];

                Console.WriteLine(String.Join("", currentRow));
            }
        }
    }
}