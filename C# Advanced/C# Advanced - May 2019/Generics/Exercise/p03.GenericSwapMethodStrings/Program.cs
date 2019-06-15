using System;
using System.Linq;

namespace p03.GenericSwapMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<string> myBox = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

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