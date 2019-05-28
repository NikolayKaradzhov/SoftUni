using System;
using System.Collections.Generic;

namespace p04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hashSet = new HashSet<int>();
            List<int> numbersList = new List<int>();
            List<int> printList = new List<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                hashSet.Add(number);
                numbersList.Add(number);
            }
        }
    }
}