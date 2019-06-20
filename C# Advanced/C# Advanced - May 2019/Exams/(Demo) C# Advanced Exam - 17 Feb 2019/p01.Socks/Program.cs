using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] leftSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] rightSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocksStack = new Stack<int>(leftSocks);
            Queue<int> rightSocksQueue = new Queue<int>(rightSocks);

            List<int> pairs = new List<int>();

            while (leftSocksStack.Count != 0 && rightSocksQueue.Count != 0)
            {
                var currentLeftSock = leftSocksStack.Peek();
                var currentRightSock = rightSocksQueue.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    pairs.Add(currentLeftSock + currentRightSock);
                    leftSocksStack.Pop();
                    rightSocksQueue.Dequeue();
                }
                else if (currentRightSock > currentLeftSock)
                {
                    leftSocksStack.Pop();
                }
                else if (currentRightSock == currentLeftSock)
                {
                    rightSocksQueue.Dequeue();
                    leftSocksStack.Pop();

                    currentLeftSock++;
                    leftSocksStack.Push(currentLeftSock);
                }
            }

            Console.WriteLine($"{pairs.Max()}");
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}