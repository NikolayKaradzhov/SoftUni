using System;

namespace p01
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int harmedVegetables = 0;
            int carrotsHarvested = 0;
            int lettuceHarvested = 0;
            int potatoHarvested = 0;

            string[][] matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                string[] vegetablesInput = Console.ReadLine()
                    .Split(" ");

                matrix[row] = vegetablesInput;
            }

            string input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                string[] commands = input
                .Split(" ");

                int rowToHarvest = int.Parse(commands[1]);
                int colToHarvest = int.Parse(commands[2]);

                if (commands[0] == "Harvest")
                {
                    if (rowToHarvest < 0
                        || rowToHarvest > matrix.Length - 1
                        || colToHarvest < 0
                        || colToHarvest > matrix[rowToHarvest].Length - 1)
                    {
                        
                    }
                    else
                    {
                        if (matrix[rowToHarvest][colToHarvest] == " ")
                        {

                        }
                        else
                        {
                            if (matrix[rowToHarvest][colToHarvest] == "C")
                            {
                                carrotsHarvested++;
                            }
                            else if (matrix[rowToHarvest][colToHarvest] == "P")
                            {
                                potatoHarvested++;
                            }
                            else if (matrix[rowToHarvest][colToHarvest] == "L")
                            {
                                lettuceHarvested++;
                            }

                            matrix[rowToHarvest][colToHarvest] = " ";
                        }
                    }
                }

                else if (commands[0] == "Mole")
                {
                    string direction = commands[3];

                    if (rowToHarvest < 0
                        || rowToHarvest > matrix.Length - 1
                        || colToHarvest < 0
                        || colToHarvest > matrix[rowToHarvest].Length - 1)
                    {
                        
                    }
                    else
                    {
                        if (direction == "up")
                        {
                            for (int row = rowToHarvest; row >= 0; row -= 2)
                            {
                                if (matrix[row][colToHarvest] == " ")
                                {

                                }
                                else
                                {
                                    matrix[row][colToHarvest] = " ";
                                    harmedVegetables++;
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int row = rowToHarvest; row < matrix.Length; row += 2)
                            {

                                if (matrix[row][colToHarvest] == " ")
                                {

                                }
                                else
                                {
                                    matrix[colToHarvest][row] = " ";
                                    harmedVegetables++;
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int col = colToHarvest; col <= 0; col -= 2)
                            {
                                if (matrix[col][rowToHarvest] == " ")
                                {

                                }
                                else
                                {
                                    matrix[rowToHarvest][col] = " ";
                                    harmedVegetables++;
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int col = colToHarvest; col <= matrix[colToHarvest].Length; col += 2)
                            {
                                if (matrix[rowToHarvest][col] == " ")
                                {

                                }
                                else
                                {
                                    matrix[rowToHarvest][col] = " ";
                                    harmedVegetables++;
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine($"Carrots: {carrotsHarvested}");
            Console.WriteLine($"Potatoes: {potatoHarvested}");
            Console.WriteLine($"Lettuce: {lettuceHarvested}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }
    }
}