using System;

namespace p01.FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPricePerPack = double.Parse(Console.ReadLine());
            double eggPricePerEgg = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double apronsTwentyPercentMore = Math.Ceiling(students + (students * 0.2));
            int freePackagesOfFlour = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freePackagesOfFlour++;
                }
            }

            double neededBudgetForCountStudents = (apronPrice * apronsTwentyPercentMore)
                + (eggPricePerEgg * 10 * students) + (flourPricePerPack * (students - freePackagesOfFlour));

            if (neededBudgetForCountStudents <= budget)
            {
                Console.WriteLine($"Items purchased for {neededBudgetForCountStudents:F2}$.");
            }
            else
            {
                double neededBudget = Math.Abs(budget - neededBudgetForCountStudents);
                Console.WriteLine($"{neededBudget:F2}$ more needed.");
            }
        }
    }
}
