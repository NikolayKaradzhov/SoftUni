using System;

namespace HelensAbduction
{
    class Program
    {
        static char[][] matrix;

        static int parisRow;
        static int parisCol;

        static int parisInitialRowPosition;
        static int parisInitialColPosition;

        static bool isInsideMatrix;

        static void Main(string[] args)
        {
            int parisEnergy = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            bool isParisDead = false;

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

                        parisInitialRowPosition = row;
                        parisInitialColPosition = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                string direction = commands[0];

                Int32.TryParse(commands[1], out int spartanSpawnRow);
                Int32.TryParse(commands[2], out int spartanSpawnCol);

                matrix[spartanSpawnRow][spartanSpawnCol] = 'S';

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

                if (matrix[parisRow][parisCol] == 'S')
                {
                    if (parisEnergy - 2 >= 0)
                    {
                        parisEnergy -= 2;
                        matrix[parisRow][parisCol] = '-';
                    }
                }

                else if (matrix[parisRow][parisCol] == 'H')
                {
                    matrix[parisRow][parisCol] = '-';
                    break;
                }

                isParisDead = parisEnergy <= 0;

                if (isParisDead)
                {
                    matrix[parisRow][parisCol] = 'X';

                    matrix[parisInitialRowPosition][parisInitialColPosition] = '-';

                    break;
                }
            }

            if (isParisDead)
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");

                foreach (var item in matrix)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                matrix[parisInitialRowPosition][parisInitialColPosition] = '-';

                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");

                foreach (var item in matrix)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}