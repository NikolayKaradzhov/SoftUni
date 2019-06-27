using System;
using System.Linq;

namespace p04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++) //number of rotations
            {
                int firstNumber = array[0]; //get the first number, so it can be on the last index(line 25)

                for (int j = 0; j < array.Length - 1; j++) //rotation
                {
                    array[j] = array[j + 1]; //move the numbers with one position
                }
                array[array.Length - 1] = firstNumber; //Last index = firstNumber
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
