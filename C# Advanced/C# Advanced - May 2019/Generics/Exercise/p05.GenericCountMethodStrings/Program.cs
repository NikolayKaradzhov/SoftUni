using System;

namespace p05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<string> myBox = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                myBox.Add(input);
            }

            string stringToCompare = Console.ReadLine();

            myBox.Compare(stringToCompare);

            int result = myBox.CountGreater;

            Console.WriteLine(result);
        }
    }
}