using System;

namespace p06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<double> myBox = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            double comparedNumber = double.Parse(Console.ReadLine());

            myBox.Compare(comparedNumber);

            int result = myBox.CountGreater;

            Console.WriteLine(result);
        }
    }
}