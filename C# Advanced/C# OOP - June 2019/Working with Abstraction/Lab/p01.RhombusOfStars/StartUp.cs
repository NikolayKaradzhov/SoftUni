namespace p01.RhombusOfStars
{ 
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i <= size; i++)
            {
                PrintRow(size, i);
            }

            for (int i = size - 1; i >= 1; i--)
            {
                PrintRow(size, i);
            }
        }

        private static void PrintRow(int size, int i)
        {
            for (int row = 1; row <= size - i; row++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}