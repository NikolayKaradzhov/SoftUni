using System;
using System.Collections.Generic;
using System.Linq;

namespace p02
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vegetables = new Queue<string>(Console.ReadLine()
                .Split());

            Stack<int> calorieValues = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            List<int> caloriesFromSalads = new List<int>();
            ;
            int tomatoCalories = 80;
            int carrotCalories = 136;
            int lettuceCalories = 109;
            int potatoCalories = 215;

            int currentCalories = 0;
            int calories = 0;

            while (vegetables.Count != 0 && calorieValues.Count != 0)
            {
                int startCalories = calorieValues.Peek();
                calories = startCalories;
                calories = currentCalories - calories;
                currentCalories = calories;

                if (currentCalories > 0)
                {
                    vegetables.Dequeue();
                }

                while (currentCalories < 0)
                {
                    var currentVegetable = vegetables.Dequeue();

                    if (vegetables.Count == 0 || calorieValues.Count == 0)
                    {
                        break;
                    }

                    if (currentVegetable == "tomato")
                    {
                        currentCalories = tomatoCalories + currentCalories;
                    }
                    else if (currentVegetable == "carrot")
                    {
                        currentCalories = carrotCalories + currentCalories;
                    }
                    else if (currentVegetable == "lettuce")
                    {
                        currentCalories = lettuceCalories + currentCalories;
                    }
                    else if (currentVegetable == "potato")
                    {
                        currentCalories = potatoCalories + currentCalories;
                    }
                }

                caloriesFromSalads.Add(startCalories);
                calorieValues.Pop();
            }

            Console.WriteLine($"{string.Join(" ", caloriesFromSalads)}");

            if (vegetables.Count > 0)
            {
                Console.WriteLine($"{string.Join(" ", vegetables)}");
            }
            else if (calorieValues.Count > 0)
            {
                Console.WriteLine($"{string.Join(" ", calorieValues)}");
            }
        }
    }
}