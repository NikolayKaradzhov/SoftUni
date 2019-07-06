using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Merging_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();

            if (firstList.Count > secondList.Count)
            {
                for (int i = 0; i < secondList.Count; i++)
                {
                    if (firstList.Count == secondList.Count)
                    {
                        newList.Add(firstList[i]);
                        newList.Add(secondList[i]);
                    }
                    else
                    {
                        newList.Add(firstList[i]);
                        newList.Add(secondList[i]);
                    }
                }
                for (int i = secondList.Count; i < firstList.Count; i++)
                {
                    newList.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (firstList.Count == secondList.Count)
                    {
                        newList.Add(firstList[i]);
                        newList.Add(secondList[i]);
                    }
                    else
                    {
                        newList.Add(firstList[i]);
                        newList.Add(secondList[i]);
                    }
                }
                for (int i = firstList.Count; i < secondList.Count; i++)
                {
                    newList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
