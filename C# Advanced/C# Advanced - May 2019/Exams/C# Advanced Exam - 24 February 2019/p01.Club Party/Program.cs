using System;
using System.Collections.Generic;

namespace p01.Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            int currentCapacity = 0;

            string[] input = Console.ReadLine()
                .Split();

            Stack<string> inputHallsAndPeople = new Stack<string>(input);
            Queue<string> halls = new Queue<string>();
            List<int> peopleInHall = new List<int>();

            while (inputHallsAndPeople.Count != 0)
            {
                string currentInput = inputHallsAndPeople.Pop();

                bool isNumeric = Int32.TryParse(currentInput, out int currentPeople);

                if (!isNumeric)
                {
                    halls.Enqueue(currentInput);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity + currentPeople < maxCapacity)
                    {
                        peopleInHall.Add(currentPeople);
                        currentCapacity += currentPeople;
                    }
                    else
                    {
                        if (halls.Count > 0)
                        {
                            var currentHall = halls.Dequeue();

                            Console.WriteLine($"{currentHall} -> {string.Join(", ", peopleInHall)}");

                            peopleInHall.Clear();
                            currentCapacity = 0;
                        }
                    }
                }
            }
        }
    }
}