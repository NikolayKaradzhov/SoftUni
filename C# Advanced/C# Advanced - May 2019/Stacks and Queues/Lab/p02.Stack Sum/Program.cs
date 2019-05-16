using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            Stack<int> stack = new Stack<int>(numbersInput);

            while (!command.Equals("end", StringComparison.InvariantCultureIgnoreCase))
            {
                string[] commandTokens = command.Split(" ");

                if (commandTokens[0].Equals("add", StringComparison.InvariantCultureIgnoreCase))
                {
                    for (int i = 1; i < commandTokens.Length; i++)
                    {
                        int currentNumber = int.Parse(commandTokens[i]);
                        stack.Push(currentNumber);
                    }
                }
                else if (commandTokens[0].Equals("remove", StringComparison.InvariantCultureIgnoreCase))
                {
                    int countToRemove = int.Parse(commandTokens[1]);

                    bool isStackCountLess = stack.Count < countToRemove;

                    if (isStackCountLess)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
