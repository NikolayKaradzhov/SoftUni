using System;

namespace p07.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[size][];

            int cols = 1;

            for (int row = 0; row < size; row++)
            {
                jaggedArray[row] = new long[cols];
                jaggedArray[row][0] = 1;
                jaggedArray[row][cols - 1] = 1;

                if (cols > 2)
                {
                    long[] previousRow = jaggedArray[row - 1];

                    for (int col = 1; col < cols - 1; col++)
                    {
                        jaggedArray[row][col] = previousRow[col] + previousRow[col - 1];
                    }
                }
                cols++;
            }
            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}