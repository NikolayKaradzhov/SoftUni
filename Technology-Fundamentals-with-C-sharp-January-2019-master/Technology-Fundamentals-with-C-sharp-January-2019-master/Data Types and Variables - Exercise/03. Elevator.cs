using System;

namespace p03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;

            int midResult = 0;

            courses = (int)Math.Ceiling((double)numberOfPeople / capacity);
            Console.WriteLine(courses);
        }
    }
}
