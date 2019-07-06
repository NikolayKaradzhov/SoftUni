using System;
using System.Collections.Generic;
using System.Linq;

namespace p09.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int elementToRemoveAtIndex = -1;
            int sum = 0;

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    elementToRemoveAtIndex = sequence[0];
                    sequence.RemoveAt(0);
                    int lastElement = sequence[sequence.Count - 1];
                    sequence.Insert(0, lastElement);
                    sum += elementToRemoveAtIndex;
                }
                else if (index > sequence.Count - 1)
                {
                    elementToRemoveAtIndex = sequence[sequence.Count - 1];
                    sequence.RemoveAt(sequence.Count - 1);
                    int firstElement = sequence[0];
                    sequence.Add(firstElement);
                    sum += elementToRemoveAtIndex;
                }
                else
                {
                    elementToRemoveAtIndex = sequence[index];
                    sequence.RemoveAt(index);
                    sum += elementToRemoveAtIndex;
                }
                IncreaseOrDecreaseValueOfAllElements(sequence, elementToRemoveAtIndex);
            }
            Console.WriteLine(sum);
        }


        private static void IncreaseOrDecreaseValueOfAllElements(List<int> sequence, int elementToRemoveAtIndex)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= elementToRemoveAtIndex)
                {
                    sequence[i] += elementToRemoveAtIndex;
                }
                else if (sequence[i] > elementToRemoveAtIndex)
                {
                    sequence[i] -= elementToRemoveAtIndex;
                }
            }
        }
    }
}
