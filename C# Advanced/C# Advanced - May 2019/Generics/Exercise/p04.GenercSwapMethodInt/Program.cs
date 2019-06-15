using System;
using System.Linq;

namespace p04.GenercSwapMethodInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            int[] indexesToSwap = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexesToSwap[0];
            int secondIndex = indexesToSwap[1];

            myBox.SwapIndexes(firstIndex, secondIndex);

            var result = myBox.ToString();

            Console.WriteLine(result);
        }
    }
}