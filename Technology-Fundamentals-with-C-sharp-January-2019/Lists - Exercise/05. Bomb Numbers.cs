using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10.Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<int> bombNumberWithPower = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int specialBombNumber = bombNumberWithPower[0];
            int power = bombNumberWithPower[1];
            int bombIndex = -1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialBombNumber)
                {
                    bombIndex = i;

                    for (int j = 0; j < power; j++)
                    {
                        if (bombIndex > 0)
                        {
                            numbers.RemoveAt(bombIndex - 1);
                        }
                        if (bombIndex > 0)
                        {
                            bombIndex = bombIndex - 1;
                        }
                        if (numbers.Count - 1 >= bombIndex + 1)
                        {
                            numbers.RemoveAt(bombIndex + 1);
                        }
                    }
                    numbers.RemoveAt(bombIndex);
                    i--;
                }
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
