using System;
using System.Collections.Generic;
using System.Linq;
 
namespace p07.Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
 
            List<string> numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
          
            for (int i = 0; i < numbers.Count; i++)
            {
                List<string> temp = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
          
                for (int j = 0; j < temp.Count; j++)
                {
                    Console.Write($"{temp[j]} ");
                }
            }
        }
    }
}
