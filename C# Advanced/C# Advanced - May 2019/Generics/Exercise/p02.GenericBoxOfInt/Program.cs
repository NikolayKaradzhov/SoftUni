using System;

namespace p02.GenericBoxOfInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            var result = myBox.ToString();

            Console.WriteLine(result);
        }
    }
}