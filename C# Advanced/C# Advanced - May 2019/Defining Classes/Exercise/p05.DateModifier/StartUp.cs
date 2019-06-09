using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dates = new DateModifier
                (DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));

            var difference = dates.ShowDifferenceBetweenTwoDates();

            Console.WriteLine(difference);
        }
    }
}