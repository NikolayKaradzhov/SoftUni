using System;

namespace p06.Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = CalculateRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
