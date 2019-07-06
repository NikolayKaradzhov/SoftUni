using System;
using System.Collections.Generic;
using System.Linq;

namespace p07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sequenceCount = 0;
            int maxSequence = 0;
            int start = 0;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    sequenceCount++;

                    if (sequenceCount > maxSequence)
                    {
                        start = i - sequenceCount + 1;
                        maxSequence = sequenceCount;
                    }
                }
                else
                {
                    sequenceCount = 0;
                }
            }
            for (int i = 0; i < maxSequence + 1; i++)
            {
                Console.Write(sequence[start] + " ");
            }
        }
    }
}
