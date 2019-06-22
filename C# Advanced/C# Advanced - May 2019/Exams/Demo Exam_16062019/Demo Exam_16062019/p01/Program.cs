using System;

namespace p01.The_Garden
{
    class Program
    {
        static string[][] matrix;

        static int currentRow;
        static int currentCol;

        static int harvestedCarrots;
        static int harvestedPotatoes;
        static int harvestedLettuce;

        static string direction;
        static int harmedVegetables;

        static void Main(string[] args)
        {
            int rowsInput = int.Parse(Console.ReadLine());

            matrix = new string[rowsInput][];

            for (int row = 0; row < matrix.Length; row++)
            {
                string[] vegetablesInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                matrix[row] = new string[vegetablesInput.Length];

                for (int col = 0; col < vegetablesInput.Length; col++)
                {
                    matrix[row][col] = vegetablesInput[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                string[] commands = input.Split();

                string command = commands[0];
                currentRow = int.Parse(commands[1]);
                currentCol = int.Parse(commands[2]);

                if (command == "Harvest")
                {
                    Harvest();
                }
                else if (command == "Mole")
                {
                    direction = commands[3];

                    Mole();
                }

                input = Console.ReadLine();
            }

            PrintMatrix();

            Console.WriteLine($"Carrots: {harvestedCarrots}");
            Console.WriteLine($"Potatoes: {harvestedPotatoes}");
            Console.WriteLine($"Lettuce: {harvestedLettuce}");

            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Mole()
        {
            if (currentRow > matrix.Length - 1 || currentRow < 0
                || currentCol < 0 || currentCol > matrix[currentRow].Length - 1)
            {

            }
            else
            {
                if (direction == "up")
                {
                    for (int row = currentRow; row >= 0; row -= 2)
                    {
                        if (matrix[row][currentCol] == " ")
                        {

                        }
                        else
                        {
                            matrix[row][currentCol] = " ";
                            harmedVegetables++;
                        }
                    }
                }
                else if (direction == "down")
                {
                    for (int row = currentRow; row <= matrix.Length; row += 2)
                    {
                        if (matrix[row][currentCol] == " ")
                        {

                        }
                        else
                        {
                            matrix[row][currentCol] = " ";
                            harmedVegetables++;
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int col = currentCol; col >= 0; col -= 2)
                    {
                        if (matrix[currentRow][col] == " ")
                        {

                        }
                        else
                        {
                            matrix[currentRow][col] = " ";
                            harmedVegetables++;
                        }
                    }
                }
                else if (direction == "right")
                {
                    for (int col = currentCol; col <= matrix[currentRow].Length; col += 2)
                    {
                        if (matrix[currentRow][col] == " ")
                        {

                        }
                        else
                        {
                            matrix[currentRow][col] = " ";
                            harmedVegetables++;
                        }
                    }
                }
            }
        }

        private static void Harvest()
        {
            if (currentRow > matrix.Length - 1 || currentRow < 0
                || currentCol < 0 || currentCol > matrix[currentRow].Length - 1)
            {

            }
            else
            {
                if (matrix[currentRow][currentCol] == "C")
                {
                    matrix[currentRow][currentCol] = " ";
                    harvestedCarrots++;
                }
                else if (matrix[currentRow][currentCol] == "P")
                {
                    matrix[currentRow][currentCol] = " ";
                    harvestedPotatoes++;
                }
                else if (matrix[currentRow][currentCol] == "L")
                {
                    matrix[currentRow][currentCol] = " ";
                    harvestedLettuce++;
                }
                else
                {

                }
            }
        }
    }
}