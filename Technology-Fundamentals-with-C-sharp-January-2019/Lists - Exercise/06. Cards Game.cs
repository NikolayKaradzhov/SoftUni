using System;
using System.Collections.Generic;
using System.Linq;

namespace p06.Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHandOfCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondHandOfCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstHandOfCards.Count != 0 || secondHandOfCards.Count != 0)
            {
                if (firstHandOfCards.Count == 0 || secondHandOfCards.Count == 0)
                {
                    break;
                }
                int firstDeckCard = firstHandOfCards[0];
                int secondDeckCard = secondHandOfCards[0];

                if (firstDeckCard > secondDeckCard)
                {
                    firstHandOfCards.Add(firstDeckCard);
                    firstHandOfCards.Add(secondDeckCard);
                    secondHandOfCards.Remove(secondDeckCard);
                    firstHandOfCards.Remove(firstDeckCard);
                }
                else if (secondDeckCard > firstDeckCard)
                {
                    secondHandOfCards.Add(secondDeckCard);
                    secondHandOfCards.Add(firstDeckCard);
                    firstHandOfCards.Remove(firstDeckCard);
                    secondHandOfCards.Remove(secondDeckCard);
                }
                else if (firstDeckCard == secondDeckCard)
                {
                    firstHandOfCards.Remove(firstDeckCard);
                    secondHandOfCards.Remove(secondDeckCard);
                }
            }
           

            int firstSum = firstHandOfCards.Sum(x => Convert.ToInt32(x));
            int secondSum = secondHandOfCards.Sum(x => Convert.ToInt32(x));

            if (firstHandOfCards.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondSum}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {firstSum}");
            }
        }
    }
}
