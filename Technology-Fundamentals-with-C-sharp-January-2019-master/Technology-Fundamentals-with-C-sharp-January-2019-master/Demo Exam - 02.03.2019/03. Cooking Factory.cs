using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Cooking_Factory_NEW
{
    class Program
    {
        static void Main(string[] args)
        {  
            int highestTotalQuality = int.MinValue;
            double highestAverageQuality = double.MinValue;
            string highestBatch = string.Empty;
            int shortestLength = int.MaxValue;

            string command = Console.ReadLine();

            while (command != "Bake It!")
            {

                List<int> batchesOfBread = command.Split("#")
                    .Select(int.Parse)
                    .ToList();

                int subTotalQualityOfBread = batchesOfBread.Sum();
                double subAverageQualityOfBread = batchesOfBread.Sum() / batchesOfBread.Count;
                int subShortestLength = batchesOfBread.Count;

                if (subTotalQualityOfBread > highestTotalQuality)
                {
                    highestTotalQuality = subTotalQualityOfBread;
                    highestAverageQuality = subAverageQualityOfBread;
                    shortestLength = subShortestLength;
                    highestBatch = string.Join(" ", batchesOfBread);
                }
                else if (subTotalQualityOfBread == highestTotalQuality
                    && subAverageQualityOfBread > highestAverageQuality)
                {
                    highestTotalQuality = subTotalQualityOfBread;
                    highestAverageQuality = subAverageQualityOfBread;
                    shortestLength = subShortestLength;
                    highestBatch = string.Join(" ", batchesOfBread);
                }
                else if (subAverageQualityOfBread == highestTotalQuality 
                    && subAverageQualityOfBread == highestAverageQuality 
                    && subShortestLength < shortestLength)
                {
                    highestTotalQuality = subTotalQualityOfBread;
                    highestAverageQuality = subAverageQualityOfBread;
                    shortestLength = subShortestLength;
                    highestBatch = string.Join(" ", batchesOfBread);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {highestTotalQuality}");
            Console.WriteLine(highestBatch);
        }
    }
}
