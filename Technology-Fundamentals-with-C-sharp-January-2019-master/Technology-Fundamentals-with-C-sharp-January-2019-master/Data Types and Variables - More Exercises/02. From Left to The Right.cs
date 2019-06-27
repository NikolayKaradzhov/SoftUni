using System;

namespace p02.From_Left_To_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string fullNumber = Console.ReadLine();
                string[] parts = fullNumber.Split(" ");
                string firstPart = parts[0];
                string secondPart = parts[1];

                long firstConvertedInt = Convert.ToInt64(firstPart);
                long secondConvertedInt = Convert.ToInt64(secondPart);

                long sum = 0;

                if (firstConvertedInt > secondConvertedInt)
                {
                    while (firstConvertedInt != 0)
                    {
                        sum += firstConvertedInt % 10;
                        firstConvertedInt /= 10;
                    }
                    Console.WriteLine(Math.Abs(sum));
                }
                else if (secondConvertedInt > firstConvertedInt)
                {
                    while (secondConvertedInt != 0)
                    {
                        sum += secondConvertedInt % 10;
                        secondConvertedInt /= 10;
                    }
                    Console.WriteLine(Math.Abs(sum));
                }
                else if (firstConvertedInt == secondConvertedInt || secondConvertedInt == firstConvertedInt)
                {
                    while (secondConvertedInt != 0)
                    {
                        sum += secondConvertedInt % 10;
                        secondConvertedInt /= 10;
                    }
                    Console.WriteLine(Math.Abs(sum));
                }
            }
        }
    }
}
