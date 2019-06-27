using System;

namespace p01.Santa_s_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfBatches = int.Parse(Console.ReadLine());

            int singleCookieGrams = 25;
            int cup = 140;
            int smallSpoon = 10;
            int bigSpoon = 20;
            int cookiesPerBox = 5;
            int box = 0;

            for (int i = 0; i < amountOfBatches; i++)
            {
                int flourGrams = int.Parse(Console.ReadLine());
                int sugarGrams = int.Parse(Console.ReadLine());
                int cocoaGrams = int.Parse(Console.ReadLine());

                int flourCups = flourGrams / cup;
                int sugarSpoons = sugarGrams / bigSpoon;
                int cocoaSpoons = cocoaGrams / smallSpoon;

                if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                    continue;
                }

                int minOfAll = Math.Min(flourCups, Math.Min(sugarSpoons, cocoaSpoons));

                int totalCookiesPerBake = ((cup + smallSpoon + bigSpoon) * minOfAll) / singleCookieGrams;

                int boxesPerBatch = totalCookiesPerBake / cookiesPerBox;

                box += boxesPerBatch;

                Console.WriteLine($"Boxes of cookies: {boxesPerBatch}");
            }
            Console.WriteLine($"Total boxes: {box}");
        }
    }
}
