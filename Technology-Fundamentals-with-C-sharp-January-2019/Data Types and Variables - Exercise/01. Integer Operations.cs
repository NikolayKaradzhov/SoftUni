using System;

namespace p01.Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int midResult = (firstNumber + secondNumber) / thirdNumber;
            int endResult = midResult * fourthNumber;

            Console.WriteLine(endResult);
        }
    }
}
