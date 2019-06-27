using System;

namespace p09.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int extractedSpice = int.Parse(Console.ReadLine());
            int totalYeld = 0;
            int daysCount = 0;
            int expectedYeld = 100;

            while (100 <= extractedSpice)
            {
                totalYeld += extractedSpice - 26;

                extractedSpice = extractedSpice - 10;

                daysCount++;
            }

            if (totalYeld >= 26)
            {
                totalYeld = totalYeld - 26;
            }

            Console.WriteLine(daysCount);
            Console.WriteLine(totalYeld);
        }
    }
}
