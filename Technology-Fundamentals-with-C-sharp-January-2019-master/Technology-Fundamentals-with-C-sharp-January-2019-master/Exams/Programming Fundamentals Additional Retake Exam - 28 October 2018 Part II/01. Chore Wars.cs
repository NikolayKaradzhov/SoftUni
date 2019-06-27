using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string patternDishes = @"<(?<dishes>[a-z0-9]*)>";
            string patternCleaning = @"\[(?<cleaning>[A-Z0-9]*)\]";
            string patternLaundry = @"{(?<laundry>.*)}";

            int dishesTime = 0;
            int cleaningTime = 0;
            int laundryTime = 0;

            string currentString = string.Empty;
            int totalTime = 0;
            int endTotalTime = 0;

            while (command != "wife is happy")
            {
                Match matchDishes = Regex.Match(command, patternDishes);
                Match matchCleaning = Regex.Match(command, patternCleaning);
                Match matchLaundry = Regex.Match(command, patternLaundry);

                if (matchDishes.Success || matchCleaning.Success || matchLaundry.Success)
                {
                    if (matchDishes.Success)
                    {
                        currentString = matchDishes.Groups["dishes"].Value;

                        foreach (var character in currentString)
                        {
                            if (Char.IsDigit(character))
                            {
                                dishesTime += Convert.ToInt32(Convert.ToString(character));
                            }
                        }
                    }
                    else if (matchCleaning.Success)
                    {
                        currentString = matchCleaning.Groups["cleaning"].Value;

                        foreach (var character in currentString)
                        {
                            if (Char.IsDigit(character))
                            {
                                cleaningTime += Convert.ToInt32(Convert.ToString(character));
                            }
                        }
                    }
                    else if (matchLaundry.Success)
                    {
                        currentString = matchLaundry.Groups["laundry"].Value;

                        foreach (var character in currentString)
                        {
                            if (Char.IsDigit(character))
                            {
                                laundryTime += Convert.ToInt32(Convert.ToString(character));
                            }
                        }
                    }
                }
                totalTime = 0;

                command = Console.ReadLine();
            }
            endTotalTime = dishesTime + cleaningTime + laundryTime;

            Console.WriteLine($"Doing the dishes - {dishesTime} min.");
            Console.WriteLine($"Cleaning the house - {cleaningTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");

            Console.WriteLine($"Total - {endTotalTime} min.");
        }
    }
}
